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
using NLog.Web;

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
							 }).ToList();
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

		//		[Authorize(Policy = Constants.CURRENT_USER)]
		//		[HttpPost("create/{userId")]
		[AllowAnonymous]
		[HttpPost("create")]
		public async Task<IActionResult> createOrder([FromBody] CartDto cart)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			//check if record in shopping cart match records in cart table
			var itemsInCartTable = _context.Carts.Where(c => c.CardId == cart.card_id).ToList();  //items in cart table
			var itemsInCartDto = cart.cartItems;
			var itemsInCartTableToObj = itemsInCartTable.ConvertAll(x => new
			{
				id = x.Id,
				card_id = x.CardId,
				code = x.Code,
				quantity = x.Quantity
			});

			var itemsInCartDtoToObj = itemsInCartDto.ConvertAll(x => new
			{
				id = x.id,
				card_id = x.card_id,
				code = x.code,
				quantity = x.quantity
			});

			if (itemsInCartTable.Count() == itemsInCartDto.Count() && itemsInCartTableToObj.All(itemsInCartDtoToObj.Contains))
			{

			}
			else
			{
				return BadRequest("Items pass to request do not match items in Cart table!");
			}

//			var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

			if (cart == null || cart.cartItems == null) //if no item in cart, return not found; 
			{
//				logger.Debug("shopping cart is empty");
				return NotFound();
			}
			//bool hasCardid = await _context.Card.AnyAsync(c => c.Id == cart.card_id);

			if (!await _context.Cards.AnyAsync(c => c.Id == cart.card_id))
			{
//				logger.Debug("This user doesn't exists, id : " + cart.card_id + "");
				return NotFound("This account does not exist, card_id :" + cart.card_id + " !");
			}

			//foreach (var item in cart.cartItems)
			//{

			//    if (!await _context.CodeRelations.AnyAsync(c => c.Code == Convert.ToInt32(item.code)))
			//    {
			//        logger.Debug("This item doesn't sell any longer, item code : "+item.code+"");
			//        return NotFound("This item does not sell any longer, item code :" + item.code + " !");
			//    }
			//}
			var inoviceInfo = new object();
			var branch_id = 1;

			//         if (await _context.Branch.AnyAsync(b => b.Name.Trim() == "Online Shop"))
			{
				branch_id = _isettings.getOnlineShopId();  //_context.Branch.Where(b => b.Name.Trim() == "Online Shop").FirstOrDefault().Id;
//				logger.Debug("Get online shop id: " + branch_id + "");
			}
			var customerGst = cart.customer_gst;
			var newOrder = new Orders();
			newOrder.CardId = cart.card_id;
			newOrder.PoNumber = cart.po_num;
			newOrder.Branch = branch_id;
			newOrder.Freight = Math.Round((decimal)(cart.freight / (1 + (decimal?)customerGst)), 4);
			newOrder.OrderTotal = (decimal)cart.sub_total;
			newOrder.ShippingMethod = (byte)cart.shipping_method;
			newOrder.CustomerGst = cart.customer_gst;
			newOrder.IsWebOrder = true;
			newOrder.WebOrderStatus = 1;
			newOrder.Status = 1;

			using (var dbContextTransaction = _context.Database.BeginTransaction())
			{
				try
				{
					await _context.Orders.AddAsync(newOrder);
					await _context.SaveChangesAsync();
					var newOrderId = newOrder.Id;
					//                  var customerGst = newOrder.CustomerGst;
					var totalGstInc = Math.Round((decimal)cart.sub_total * (1 + (decimal)customerGst), 2);
					await inputOrderItem(cart.cartItems, newOrderId, customerGst);
					inoviceInfo = await CreateInvoiceAsync(cart, newOrderId);
					await ClearShoppingCart(cart.card_id);
					await inputShippingInfo(cart.shippingInfo, newOrderId);

					await _context.SaveChangesAsync();
					dbContextTransaction.Commit();
					return Ok(inoviceInfo);
				}
				catch (Exception ex)
				{
					dbContextTransaction.Rollback();
//					logger.Error(ex.ToString());
					return BadRequest(ex.ToString());
				}
				finally
				{
					NLog.LogManager.Shutdown();
				}

			}

		}
		private async Task<IActionResult> CreateInvoiceAsync([FromBody] CartDto cart, int orderid)
		{
			if (cart == null || cart.cartItems == null) //if no item in cart, return not found; 
			{
				return NotFound();
			}

			if (!_context.Cards.Any(c => c.Id == cart.card_id))
			{
				return NotFound("This account does not exist, card_id :" + cart.card_id + " !");
			}

			if (!_context.Orders.Any(o => o.Id == orderid))
			{
				return NotFound("This order does not exist, card_id :" + cart.card_id + " !");
			}

			var customerGst = cart.customer_gst;
			var currentOrder = _context.Orders.Where(o => o.Id == orderid).FirstOrDefault();
			var branch = _context.Orders.Where(o => o.Id == orderid).FirstOrDefault().Branch;
			var shippingMethod = _context.Orders.Where(o => o.Id == orderid).FirstOrDefault().ShippingMethod;
			var freightTax = cart.freight - Math.Round((decimal)(cart.freight / (1 + (decimal?)customerGst)), 4);

			var newInvoice = new Invoice();
			newInvoice.Branch = branch;
			newInvoice.CardId = cart.card_id;
			newInvoice.Price = (decimal?)cart.sub_total;
			newInvoice.ShippingMethod = shippingMethod;
			newInvoice.Tax = (decimal?)cart.tax + freightTax;
			newInvoice.Freight = Math.Round((decimal)(cart.freight / (1 + (decimal?)customerGst)), 4);
			newInvoice.Total = (decimal?)(cart.total);// + cart.freight);
			newInvoice.CommitDate = DateTime.Now;
			newInvoice.ShippingMethod = (byte)cart.shipping_method;
			_context.Add(newInvoice);
			_context.SaveChanges();

			var invoiceNumber = newInvoice.Id;

			currentOrder.InvoiceNumber = invoiceNumber;
			newInvoice.InvoiceNumber = invoiceNumber;
			_context.SaveChanges();

			IActionResult a = await inputSalesItem(cart.cartItems, invoiceNumber, customerGst);

			return Ok(new { orderid, invoiceNumber, newInvoice.Total });
		}
		private async Task<IActionResult> inputOrderItem(List<CartItemDto> itemsInCart, int? orderId, double? customerGst)
		{

			if (itemsInCart == null || orderId == null)
			{
				return NotFound("Nothing in shopping cart!");
			}
			foreach (var item in itemsInCart)
			{
				var newOrderItem = new OrderItem();
				newOrderItem.Id = orderId.GetValueOrDefault();
				newOrderItem.Code = Convert.ToInt32(item.code);
				newOrderItem.ItemName = item.name;
				newOrderItem.Note = item.note;
				newOrderItem.Quantity = Convert.ToDouble(item.quantity);
				newOrderItem.SupplierCode = item.supplier_code ?? "";
				newOrderItem.Supplier = "";
				newOrderItem.CommitPrice = Convert.ToDecimal(item.sales_price) / Convert.ToDecimal(1 + customerGst ?? 0.15);

				newOrderItem.Cat = _iitem.getCat("cat", newOrderItem.Code); // _context.CodeRelations.Where(c => c.Code == Convert.ToInt32(item.code)).FirstOrDefault().Cat;
				newOrderItem.SCat = _iitem.getCat("scat", newOrderItem.Code);  //_context.CodeRelations.Where(c => c.Code == Convert.ToInt32(item.code)).FirstOrDefault().SCat;
				newOrderItem.SsCat = _iitem.getCat("sscat", newOrderItem.Code);  //_context.CodeRelations.Where(c => c.Code == Convert.ToInt32(item.code)).FirstOrDefault().SsCat;
				await _context.AddAsync(newOrderItem);
			}
			//         await _context.SaveChangesAsync();
			return Ok();
		}
		private async Task<IActionResult> inputSalesItem(List<CartItemDto> itemsInCart, int? inoviceNumber, double? customerGst)
		{

			if (itemsInCart == null || inoviceNumber == null)
			{
				return NotFound("Cannot find inoivce!");
			}
			foreach (var item in itemsInCart)
			{
				var newSales = new Sale();
				newSales.InvoiceNumber = inoviceNumber.GetValueOrDefault();
				newSales.Code = Convert.ToInt32(item.code);
				newSales.Name = item.name;
				newSales.Note = item.note;
				newSales.Quantity = Convert.ToDouble(item.quantity);
				newSales.SupplierCode = item.supplier_code ?? "";
				newSales.Supplier = "";
				newSales.CommitPrice = Convert.ToDecimal(item.sales_price) / Convert.ToDecimal(1 + customerGst ?? 0.15);

				newSales.Cat = _iitem.getCat("cat", newSales.Code); //_context.CodeRelations.Where(c => c.Code == Convert.ToInt32(item.code)).FirstOrDefault().Cat;
				newSales.SCat = _iitem.getCat("scat", newSales.Code); //_context.CodeRelations.Where(c => c.Code == Convert.ToInt32(item.code)).FirstOrDefault().SCat;
				newSales.SsCat = _iitem.getCat("sscat", newSales.Code); //_context.CodeRelations.Where(c => c.Code == Convert.ToInt32(item.code)).FirstOrDefault().SsCat;
				await _context.AddAsync(newSales);
			}
			//          await _context.SaveChangesAsync();
			return Ok();
		}

		private async Task<IActionResult> ClearShoppingCart(int card_id)
		{
			var recordAffected = _context.Carts.Where(c => c.CardId == card_id).ToList();
			if (recordAffected.Count == 0)
				return NotFound();
			if (recordAffected.Count > 0)
			{
				_context.RemoveRange(recordAffected);
				await _context.SaveChangesAsync();
			}
			return Ok();
		}
		private async Task<IActionResult> inputShippingInfo(ShippingInfoDto shippingInfo, int? orderId)
		{
			if (shippingInfo == null || orderId == null)
			{
				return NotFound("No shipping address or order_id!");
			}
			shippingInfo.orderId = orderId.GetValueOrDefault();
			var newShipping = new ShippingInfo();
			newShipping.orderId = shippingInfo.orderId;
			newShipping.sender = shippingInfo.sender;
			newShipping.sender_phone = shippingInfo.sender_phone;
			newShipping.sender_address = shippingInfo.sender_address;
			newShipping.sender_city = shippingInfo.sender_city;
			newShipping.sender_country = shippingInfo.sender_country;

			newShipping.receiver = shippingInfo.receiver;
			newShipping.receiver_phone = shippingInfo.receiver_phone;
			newShipping.receiver_address1 = shippingInfo.receiver_address1;
			newShipping.receiver_address2 = shippingInfo.receiver_address2;
			newShipping.receiver_address3 = shippingInfo.receiver_address3;
			newShipping.receiver_city = shippingInfo.receiver_city;
			newShipping.receiver_country = shippingInfo.receiver_country;
			newShipping.receiver_company = shippingInfo.receiver_company;
			newShipping.receiver_contact = shippingInfo.receiver_contact;
			newShipping.note = shippingInfo.note;

			await _context.ShippingInfo.AddAsync(newShipping);
			await _context.SaveChangesAsync();
			return Ok();
		}

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
