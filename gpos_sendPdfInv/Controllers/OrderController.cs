using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce_API.Dto;
using eCommerce_API_RST.Dto;
using gpos_sendPdfInv.Entities;
using gpos_sendPdfInv.Services;
using gpos_sendPdfInv.Services.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace gpos_sendPdfInv.Controllers
{
	[Authorize]
	[Route("api/order")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly admingposContext _context;
		private readonly ILogger<OrderController> _logger;
		private readonly IConfiguration _config;
		private readonly iMailService _mail;
        private readonly IItem _iitem;
        private readonly ISetting _isettings;
        private readonly IOrder _iorder;

        public OrderController(admingposContext context,
								ILogger<OrderController> logger,
								IItem iitem,
								ISetting isettings,
								IOrder iorder,
								IConfiguration config,
								iMailService mail)
		{
			_context = context;
			_logger = logger;
			_iitem = iitem;
			_isettings = isettings;
			//_iorder = iorder;
			_config = config;
			_mail = mail;
		}

        [Authorize(Policy = Constants.CURRENT_USER)]
        [HttpGet("userId")]
        public IActionResult getOrders(int userId, [FromQuery] bool? invoiced, [FromQuery] bool? paid, [FromQuery] int? status, [FromQuery] string customer,
    [FromQuery] DateTime start, [FromQuery] DateTime end, [FromQuery] string keyword)
        {
            var filter = new OrderFilterDto();
            filter.userId = userId;
            filter.inoviced = invoiced;
            filter.paid = paid;
            filter.status = status;
            filter.customer = customer;
            if (start != DateTime.MinValue)
                filter.start = start;
            if (end != DateTime.MinValue)
                filter.end = end;
            filter.keyword = keyword;

            var orderList = orderlist(filter);
            return Ok(orderList);
        }

        private List<OrderDto> orderlist([FromBody] OrderFilterDto filter)
        {

            _context.ChangeTracker.QueryTrackingBehavior
                = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
            OrderListDto orderListDto = new OrderListDto();
            var orderList = (from o in _context.Orders
                             join i in _context.Invoices on o.InvoiceNumber equals i.InvoiceNumber into oi
                             from i in oi.DefaultIfEmpty()

                             join si in _context.ShippingInfo on o.Id equals si.orderId into sio
                             from si in sio.DefaultIfEmpty()

                             where o.CardId == filter.userId
                             //&& (filter.paid != null ? i.Paid == filter.paid : true)
                             //&& (filter.status != null ? i.Status == filter.status : true)
                             //&& (filter.start != null ? o.RecordDate >= filter.start : true) && (filter.end != null ? o.RecordDate <= filter.end : true)
                             //&& (filter.keyword != null ? i.InvoiceNumber.ToString().Contains(filter.keyword) || o.PoNumber.ToString().Contains(filter.keyword) : true)
                             select new OrderDto
                             {
                                 id = o.Id,
                                 card_id = o.CardId,
                                 branch = o.Branch,
                                 po_number = o.PoNumber,
                                 status = _isettings.getOrderStatus(Convert.ToInt32(o.Status)), //o.Status.ToString(),
                                 invoice_number = o.InvoiceNumber,
                                 TotalAmount_GstIncl = i.Total,
                                 TotalAmount_GSTExcl = i.Price,
                                 GstAmount = i.Tax,
                                 record_date = o.RecordDate,
                                 shipto = o.Shipto,
                                 special_shipto = o.SpecialShipto,
                                 date_shipped = o.DateShipped,
                                 freight = o.Freight,
                                 ticket = o.Ticket,
                                 shipping_method = o.ShippingMethod,
                                 payment_type = o.PaymentType,
                                 paid = _iorder.getOrderPaymentStatus(o.Id),//o.Paid,
                                 receiver_name = si.receiver,
                                 receiver_phone = si.receiver_phone,
                                 is_web_order = true,
                                 freightInfo = _iorder.getSupplierShippingInfo(o.Id),
                                 web_order_status = o.WebOrderStatus
                             }).ToList() ;
            return orderList;
        }


    }
}
