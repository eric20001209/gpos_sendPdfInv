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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using System.Net.Http;

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
			_iorder = iorder;
			_config = config;
			_mail = mail;
		}

        [Authorize(Policy = Constants.CURRENT_USER)]
        [HttpGet("orders/{userId}")]
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

        [Authorize(Policy = Constants.ORDER_BELONG_TO_USER)]
        [HttpPut("shipping/{orderId}")]
        public async Task<IActionResult> updateOrderShipping(int? orderId)
        {
            var orderToUpdate = _context.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            if (orderToUpdate == null)
                return NotFound();
            var shippingStatus = orderToUpdate.Status;
            if (shippingStatus == 5)
                orderToUpdate.Status = 6;    //from shipping to received
            else if (shippingStatus == 6)
                orderToUpdate.Status = 5;    //from received to shipping
            try
            {
                _context.Update(orderToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return NoContent();
        }

        [Authorize(Policy = Constants.ORDER_BELONG_TO_USER)]
        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> orderDetail(int? orderId)
        {
            if (orderId == null)
            {
                _logger.LogInformation($"Order with id {orderId} was null.");
                return NotFound();
            }

            if (!await _context.Orders.AnyAsync(o => o.Id == orderId))
            {
                _logger.LogInformation($"Order with id {orderId} wasn't found.");
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Order with id {orderId} was found.");
            }

            try
            {
                var orderDetail = new OrderDetailDto();

                var myOrder = _context.Orders.Where(o => o.Id == orderId)
                    .Include(b => b.shippinginfo)
                    .Include(b => b.invoiceFreight)
                    .Join(_context.Invoices.Select(i => new { i.InvoiceNumber, i.Paid, i.PaymentType, i.Freight, i.Total, i.Tax, i.Price }),
                    (b => b.InvoiceNumber),
                    (i => i.InvoiceNumber),
                    (b, i) => new { b.shippinginfo, b.invoiceFreight, b.Id, b.ShippingMethod, b.InvoiceNumber, b.PoNumber, b.CustomerGst, b.CardId, i.Freight, OrderTotal = i.Price, i.Total, i.Tax, b.WebOrderStatus, b.Status, i.Paid, i.PaymentType })

                    .Join(_context.Enums.Where(e => e.Class == "payment_method"),
                    (b => (int)b.PaymentType),
                    (e => e.Id),
                    (b, e) => new { b.shippinginfo, b.invoiceFreight, b.Id, b.ShippingMethod, b.InvoiceNumber, b.PoNumber, b.CustomerGst, b.CardId, b.Freight, b.OrderTotal, b.Total, b.Tax, b.WebOrderStatus, b.Status, b.Paid, PaymentType = e.Name })

                    //.Join(_context.Enum.Where(e => e.Class == "web_order_status"),
                    //(b => b.WebOrderStatus),
                    //(e => e.Id),
                    //(b, e) => new { b.shippinginfo, b.invoiceFreight, b.Id, b.ShippingMethod, b.InvoiceNumber, b.PoNumber, b.CustomerGst, b.CardId, b.Freight, b.OrderTotal, b.Total, b.Tax, WebOrderStatus = e.Name, b.Paid, b.PaymentType })

                    .FirstOrDefault();
                if (myOrder == null)
                {
                    _logger.LogInformation($"Order with id {orderId} was null.");
                    return NotFound();
                }

                var customerGst = myOrder.CustomerGst;

                var orderItem = _context.OrderItem.Where(o => o.Id == orderId)
                    .Select(oi => new OrderItemDto
                    {
                        Kid = oi.Kid,
                        Id = oi.Id,
                        Code = oi.Code,
                        SupplierCode = oi.SupplierCode,
                        Quantity = oi.Quantity,
                        ItemName = oi.ItemName,
                        ItemNameCn = oi.ItemNameCn,
                        CommitPrice = oi.CommitPrice,
                        PriceGstInc = Math.Round(oi.CommitPrice * Convert.ToDecimal(1 + customerGst), 2),
                        Cat = oi.Cat,
                        Note = oi.Note
                    }).ToListAsync();

                var shippingInfo = myOrder.shippinginfo
                    .Select(s => new ShippingInfoDto
                    {
                        id = s.id,
                        sender = s.sender,
                        orderId = s.orderId,
                        sender_phone = s.sender_phone,
                        sender_address = s.sender_address,
                        sender_city = s.sender_city,
                        sender_country = s.receiver_country,
                        receiver = s.receiver,
                        receiver_company = s.receiver_company,
                        receiver_address1 = s.receiver_address1,
                        receiver_address2 = s.receiver_address2,
                        receiver_address3 = s.receiver_address3,
                        receiver_city = s.receiver_city,
                        receiver_country = s.receiver_country,
                        receiver_phone = s.receiver_phone,
                        receiver_contact = s.receiver_contact,
                        note = s.note
                    })
                    .FirstOrDefault();

                if (shippingInfo == null)
                {
                    shippingInfo = new ShippingInfoDto
                    {
                        sender = "",
                        sender_phone = "",
                        sender_address = "",
                        sender_city = "",
                        sender_country = "",
                        receiver = "",
                        receiver_company = "",
                        receiver_address1 = "",
                        receiver_address2 = "",
                        receiver_address3 = "",
                        receiver_city = "",
                        receiver_country = "",
                        receiver_phone = "",
                        receiver_contact = "",
                        note = ""
                    };
                }



                List<FreightInfoDto> freightInfo = myOrder.invoiceFreight
                    .Select(i => new FreightInfoDto
                    {
                        ship_name = i.ShipName,
                        ship_desc = i.ShipDesc,
                        ship_id = i.ShipId.Value,
                        ticket = i.Ticket,
                        price = i.Price

                    }).ToList();

                orderDetail.invoice_number = myOrder.InvoiceNumber.Value;
                orderDetail.po_number = myOrder.PoNumber;
                orderDetail.card_id = myOrder.CardId;
                orderDetail.freight = (double)myOrder.Freight * (1 + customerGst);
                orderDetail.order_id = myOrder.Id;
                orderDetail.total = (double)myOrder.Total;
                orderDetail.sub_total = (double)myOrder.OrderTotal;
                orderDetail.tax = (double)myOrder.Tax;
                orderDetail.payment_method = (myOrder.PaymentType);
                orderDetail.status = _isettings.getOrderStatus(Convert.ToInt32(myOrder.Status));// (myOrder.WebOrderStatus);
                orderDetail.paid = _iorder.getOrderPaymentStatus(orderId ?? 0);
                orderDetail.orderItems = await orderItem;
                orderDetail.shippingInfo = shippingInfo;
                orderDetail.shipping_method = myOrder.ShippingMethod;
                orderDetail.freightInfo = freightInfo;

                return Ok(orderDetail);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Exception while getting order detail with order_id {orderId}.");

                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [Authorize(Policy = Constants.ORDER_BELONG_TO_USER)]
        [HttpPatch("UpdateShippingStatus/{orderId}")]
        public async Task<IActionResult> SendEmailToCustomerByOrderId(int orderId, [FromBody] JsonPatchDocument<UpdateShippingStatusDto> patchDoc)
        {
            try
            {
                //step 1. update order status to 'shipping'
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
                if (orderToUpdate == null)
                    return NotFound("This order does not exist!");
                var itemToPatch = new UpdateShippingStatusDto
                {
                    Status = orderToUpdate.Status ?? 0
                };
                patchDoc.ApplyTo(itemToPatch, ModelState);
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                orderToUpdate.Status = itemToPatch.Status;
                await _context.SaveChangesAsync();

                //step 2. send email to notice customer
                var cardId = orderToUpdate.CardId;
                var customer = await _context.Cards.FirstOrDefaultAsync(c => c.Id == cardId);
                if (customer == null)
                    return NotFound();
                var customerEmail = customer.Email;
                await _mail.sendEmail(customerEmail, "Shipping", "DoNotReply! <br><br> Dear customer: <br>Your order has been shipped.<br>Please check shipping detail from <a href='http://dollaritems.co.nz/ecom'> dollaritems.co.nz</a>.", null);

                return Ok("Shipping status updated!");
            }
            catch (Exception)
            {

                throw;
            }

        }

        [Authorize(Policy = Constants.ORDER_BELONG_TO_USER)]
        [HttpGet("SendOrderToSupplier/{orderId}")]
        public async Task<IActionResult> SendOrderToSupplier(int orderId)
        {
            var hasOrder = await _context.Orders.AnyAsync(o => o.Id == orderId);
            if (!hasOrder)
                return BadRequest("order " + orderId + " not exists! ");

            var dealerId = _config["DealerId"];
            var apiUrl = _config["ApiUrl"];
            var siteName = _config["SiteName"];

            var sales_note = _context.Orders.Where(o => o.Id == orderId).FirstOrDefault().SalesNote;
            var shipping_method = _context.Orders.Where(o => o.Id == orderId).FirstOrDefault().ShippingMethod;
            var freight = _context.Orders.Where(o => o.Id == orderId).FirstOrDefault().Freight;
            var shippingInfo = _context.ShippingInfo.Where(o => o.orderId == orderId).FirstOrDefault();
            var shppingInfoDto = new ShippingInfoDto();
            if (shippingInfo != null)
            {
                shppingInfoDto = new ShippingInfoDto()
                {
                    id = shippingInfo.id,
                    sender = shippingInfo.sender,
                    sender_phone = shippingInfo.sender_phone,
                    sender_address = shippingInfo.sender_address,
                    sender_city = shippingInfo.sender_city,
                    sender_country = shippingInfo.sender_country,
                    orderId = shippingInfo.orderId,
                    note = shippingInfo.note,
                    receiver = shippingInfo.receiver,
                    receiver_address1 = shippingInfo.receiver_address1,
                    receiver_address2 = shippingInfo.receiver_address2,
                    receiver_address3 = shippingInfo.receiver_address3,
                    receiver_city = shippingInfo.receiver_city,
                    receiver_company = shippingInfo.receiver_company,
                    receiver_contact = shippingInfo.receiver_contact,
                    receiver_country = shippingInfo.receiver_country,
                    receiver_phone = shippingInfo.receiver_phone,
                    receiver_zip = shippingInfo.zip,
                    oversea = false
                };
            }
            else
                shppingInfoDto = null;

            var orderItems = _context.OrderItem.Where(oi => oi.Id == orderId)
                            .Select(i => new CartItemDto
                            {
                                code = i.Code.ToString(),
                                quantity = i.Quantity.ToString(),
                                barcode = i.Barcode,
                                name = i.ItemName,
                                id = i.Id,
                                note = i.Note,
                                supplier_code = i.SupplierCode
                            }).ToList();

            var newCreateOrderByDealerId = new CreateOrderByDealerIdDto()
            {
                freight = freight,
                sales_note = sales_note,
                shipping_method = shipping_method,
                ShippingInfo = shppingInfoDto,
                cartItems = orderItems
            };
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    //check if this order has been sent already!
                    var responseTask = client.GetAsync("/" + siteName + "/api/dealer/order/po/eCom_Managment_" + orderId);
                    responseTask.Wait();
                    var final = responseTask.Result;
                    if (final.IsSuccessStatusCode)
                    {
                        var readTask = final.Content.ReadAsAsync<bool>();
                        readTask.Wait();
                        var myfinal = readTask.Result;
                        if (myfinal)
                            return BadRequest("order exists already!");
                    }

                    var content = newCreateOrderByDealerId;
                    var postTask = client.PostAsJsonAsync<CreateOrderByDealerIdDto>("/" + siteName + "/api/dealer/order/createOrderByDealerId/" + dealerId + "/" + orderId, content);
                    postTask.Wait();

                    var reault = postTask.Result;
                    if (reault.IsSuccessStatusCode)
                    {
                        return Ok("order sent!");
                    }
                    else
                    {
                        return BadRequest("something wrong!");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("SendOrderToSupplier/{orderId}")]
        [HttpDelete("del/{orderId}")]
        public async Task<IActionResult> deleteOrder(int? orderId)
        {
            if (orderId == null)
                return NotFound();
            var orderToDel = _context.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            orderToDel.OrderDeleted = 1;
            orderToDel.WebOrderStatus = 2;
            _context.Update(orderToDel);
            //var orderItemToDel = _context.OrderItem.Where(oi => oi.Id == id).ToList();
            //var invoiceToDel = _context.Invoice.Where(i => i.InvoiceNumber == orderToDel.InvoiceNumber).FirstOrDefault();
            //var salesTodel = _context.Sales.Where(s => s.InvoiceNumber == orderToDel.InvoiceNumber).ToList();
            //_context.Orders.Remove(orderToDel);
            //_context.OrderItem.RemoveRange(orderItemToDel);
            //_context.Invoice.Remove(invoiceToDel);
            //_context.Sales.RemoveRange(salesTodel);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
