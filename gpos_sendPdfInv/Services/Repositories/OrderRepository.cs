﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eCommerce_API.Dto;
using gpos_sendPdfInv.Entities;
using Microsoft.Extensions.Configuration;

namespace gpos_sendPdfInv.Services.Repositories
{
	public interface IOrder
	{
		bool? getOrderPaymentStatus(int order_id);
		List<PaymentDto> getPayment(int invoice_number);
		List<FreightInfoDto> getSupplierShippingInfo(int order_id);
		InvoiceDto getOrderDetail(int order_id);
	}
	public class OrderRepository : IOrder
	{
		private readonly admingposContext _context;
		ISetting _isettings;
		private readonly IConfiguration _config;
		public OrderRepository(admingposContext context, ISetting isettings, IConfiguration config)
		{
			_context = context;
			_isettings = isettings;
			_config = config;
		}

		public List<PaymentDto> getPayment(int invoice_number)
		{
			List<PaymentDto> test = new List<PaymentDto>();
			var paymentList = _context.TranInvoices.Where(ti => ti.InvoiceNumber == invoice_number)
								.Join(_context.TranDetails.Select(td => new { td.InvoiceNumber, td.Id, td.PaymentMethod }), ti => ti.TranId, td => td.Id,
								(ti, td) => new { ti.InvoiceNumber, ti.AmountApplied, ti.TranId, td.PaymentMethod })
								.ToList();
			var final = paymentList.Join(_context.Enums.Where(e => e.Class == "payment_method"), t => t.PaymentMethod, e => e.Id, (t, e) => new PaymentDto { amount = t.AmountApplied, payment_method = e.Name }).ToList();

			return final;
		}
		public bool? getOrderPaymentStatus(int order_id)
		{
			var order = _context.Orders.Where(o => o.Id == order_id).FirstOrDefault();
			if (order == null)
				return null;
			if (order.InvoiceNumber == null || order.InvoiceNumber == 0)
				return null;
			else
			{
				var invoice = _context.Invoices.Where(i => i.InvoiceNumber == order.InvoiceNumber).FirstOrDefault();
				if (invoice == null)
					return null;
				return invoice.Paid;
			}
		}
		public InvoiceDto getOrderDetail(int orderId)
		{
			InvoiceDto invoice = new InvoiceDto();
			_context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;  //saving garbage collection

			var order = _context.Orders.Where(o => o.Id == orderId).Include(o=>o.shippinginfo);

			var invoiceDetail = order
							.Join(_context.Invoices.Select(i => new { i.InvoiceNumber, i.Total, i.CommitDate, i.Tax, i.Freight }),
							(o => o.InvoiceNumber),
							(i => i.InvoiceNumber),
							(o, i) => new { o.InvoiceNumber, o.Id, o.shippinginfo, o.OrderTotal, i.Total, i.CommitDate, i.Tax, i.Freight })
//							.Include(o => o.shippinginfo)
							.FirstOrDefault();
			if (invoiceDetail == null)
				return null;

			var commite_date = invoiceDetail.CommitDate;
			var tax = invoiceDetail.Tax;
			var total = invoiceDetail.Total;
			var invoiceNumber = invoiceDetail.InvoiceNumber ?? 0;
			var freight = invoiceDetail.Freight ?? 0;
			var subTotal = invoiceDetail.OrderTotal;
			var poBox = _config["POBox"];
			var gst = _config["GST"];
			var itemList = _context.OrderItem.Where(oi => oi.Id == orderId)
						   .Select(oi => new OrderItemDto
						   {
							   Code = oi.Code,
							   Quantity = oi.Quantity,
							   ItemName = oi.ItemName,
							   CommitPrice = oi.CommitPrice,
							   OrderTotal = (double)oi.CommitPrice * oi.Quantity,
							   ImageUrl = _config["Url"] + "/pi/" + oi.Code + ".jpg",
							   Note = oi.Note

						   }).ToList();
			var thisOrder = _context.Orders.Include(o => o.shippinginfo).FirstOrDefault(o => o.Id == orderId);
			var payment = this.getPayment(invoiceNumber);
			var shippinginfo = thisOrder.shippinginfo.FirstOrDefault();
			var shippingTo = new ShippingToDto();
			if (shippinginfo != null)
			{
				shippingTo.address1 = shippinginfo.receiver_address1;
				shippingTo.address2 = shippinginfo.receiver_address2;
				shippingTo.address3 = shippinginfo.receiver_address3;
				shippingTo.city = shippinginfo.receiver_city;
				shippingTo.name = shippinginfo.receiver;
				shippingTo.phone = shippinginfo.receiver_phone;
				shippingTo.note = shippinginfo.note;
			}

			invoice.commit_date = commite_date;
			invoice.inovice_number = invoiceNumber;
			invoice.order_id = orderId;
			invoice.tax = tax ?? 0;
			invoice.sub_total = subTotal;
			invoice.total = total ?? 0;
			invoice.sales_items = itemList;
			invoice.payment = payment;
			invoice.freight = freight;
			invoice.shipto = shippingTo;
			invoice.po_box = poBox;
			invoice.gst = gst;

			return invoice;
		}

		public List<FreightInfoDto> getSupplierShippingInfo(int orderId)
		{
			var management = _config["Management"];
			if (management == "true")
			{
				var apiUrl = _config["ApiUrl"];     //supplier url
				var siteName = _config["SiteName"];     //supplier site name
				try
				{
					using (var client = new HttpClient())
					{
						client.BaseAddress = new Uri(apiUrl);

						var responseTask = client.GetAsync("/" + siteName + "/api/invoice/freightInfo/" + orderId);
						responseTask.Wait();
						var getResult = responseTask.Result;
						if (getResult.IsSuccessStatusCode)
						{
							var readTask = getResult.Content.ReadAsAsync<List<FreightInfoDto>>();
							readTask.Wait();
							var freightInfoList = readTask.Result;
							return freightInfoList;
						}
					}
				}
				catch (Exception)
				{

					throw;
				}
				return new List<FreightInfoDto>();
			}
			else
			{
				try
				{
					int invoice_number = 0;
					var order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
					if (order != null)
						invoice_number = order.InvoiceNumber ?? 0;
					var freight = _isettings.getFreightInfo(invoice_number);
					return freight;
				}
				catch (Exception)
				{

					throw;
				}
				return new List<FreightInfoDto>();
			}
		}
	}
}
