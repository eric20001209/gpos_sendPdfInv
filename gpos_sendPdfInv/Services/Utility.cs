using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpos_sendPdfInv.Models;
using gpos_sendPdfInv.Entities;
using Microsoft.Extensions.Configuration;

namespace gpos_sendPdfInv.Services
{
	public interface IInvoice
	{
		InvoiceDetail getInvoiceDetail(int invoiceNumber);
		string getTandC();
	}
	public class Utility : IInvoice
	{
		private readonly admingposContext _context;
		private readonly IConfiguration _config;
		public Utility(admingposContext context, IConfiguration config)
		{
			_context = context;
			_config = config;
		}
		public InvoiceDetail getInvoiceDetail(int invoiceNumber)
		{
			InvoiceDetail invoiceDetail = new InvoiceDetail();
			var invoice =  _context.Invoices.Where(i => i.InvoiceNumber == invoiceNumber).FirstOrDefault();
			if (invoice == null)
				return null;

			var commit_date = invoice.CommitDate;
			var price = invoice.Price;
			var tax = invoice.Tax;
			var total = invoice.Total;
			var freight = invoice.Freight ?? 0;
			var amountPaid = invoice.AmountPaid;
			var sales = invoice.Sales;
			var customerGst = invoice.CustomerGst;
			var salesItems =  _context.Sales.Where(s => s.InvoiceNumber == invoiceNumber)
							.Select(s => new SalesItem
							{
								Code = s.Code,
								Quantity = s.Quantity,
								ItemName = s.Name,
								CommitPrice = s.CommitPrice,
								OrderTotal = (double)s.CommitPrice * s.Quantity,
								ImageUrl = _config["Url"] + "/pi/" + s.Code + ".jpg",
								Note = s.Note
							}).ToList();
			var payment = this.getPayment(invoiceNumber);

			invoiceDetail.commit_date = commit_date ;
			invoiceDetail.inovice_number = invoiceNumber;
			invoiceDetail.tax = tax ?? 0;
			invoiceDetail.sub_total = price ?? 0;
			invoiceDetail.total = total ?? 0;
			invoiceDetail.sales_items = salesItems;
			invoiceDetail.payment = payment;
			invoiceDetail.freight = freight;
			invoiceDetail.gst = _config["GST"];

			return invoiceDetail;
		}

		public string getTandC()
		{
			var termsAndCondition = _context.SitePages.Where(sp => sp.Name == "invoice_footer" && sp.Cat == "Form Templates").FirstOrDefault();
			if (termsAndCondition != null)
			{
				var result = termsAndCondition.Text;
				return result;
			}
			return "";	
		}

		//get paymentinfo
		private List<PaymentInfo> getPayment(int invoice_number)
		{
			List<PaymentInfo> test = new List<PaymentInfo>();
			var paymentList = _context.TranInvoices.Where(ti => ti.InvoiceNumber == invoice_number)
								.Join(_context.TranDetails.Select(td => new { td.InvoiceNumber, td.Id, td.PaymentMethod }), ti => ti.TranId, td => td.Id,
								(ti, td) => new { ti.InvoiceNumber, ti.AmountApplied, ti.TranId, td.PaymentMethod })
								.ToList();
			var final = paymentList.Join(_context.Enums.Where(e => e.Class == "payment_method"), 
							t => t.PaymentMethod, e => e.Id, (t, e) => new PaymentInfo { amount = t.AmountApplied, payment_method = e.Name }).ToList();

			return final;
		}
	}
}
