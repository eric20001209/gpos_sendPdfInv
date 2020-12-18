using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
	[AllowAnonymous]
	[Route("api/dps")]
	[ApiController]
	public class DpsPaymentController : ControllerBase
	{
		private readonly admingposContext _context; //= new rst374_cloud12Context();
		private ILogger<DpsPaymentController> _logger;
		private readonly ISetting _isettings;
		private readonly IConfiguration _config;
		private readonly iMailService _mail;
		private string PxPayUserId = Startup.Configuration["Dps:PxPayUserId"]; 
		private string PxPayKey = Startup.Configuration["Dps:PxPayKey"]; 
		private string sServiceUrl = Startup.Configuration["Dps:sServiceUrl"];

		public DpsPaymentController(ILogger<DpsPaymentController> logger
									, admingposContext context
									, ISetting isettings
									, IConfiguration config
									, iMailService mail)
		{
			_logger = logger;
			_context = context;
			_isettings = isettings;
			_config = config;
			_mail = mail;
		}

        [HttpPost()]
        public IActionResult CreateDpsUI([FromBody] DpsInputDto dpsInput)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input!");
            var orderId = dpsInput.OrderId;
            var returnUrl = dpsInput.ReturnUrl;

            var siteName = _config["CurrentSite"];
            string host_url = "http://" + HttpContext.Request.Host + siteName;
            string host_url1 = _config["ApiUrl"] + siteName; // "http://api171.gpos.nz/dollaritems";
            string sReturnUrlFail =
                                  host_url1
                                 //"localhost:8088"
                                 + "/api/dps/result?t=result&ret=fail&orderId=" + orderId;
            string sReturnUrlSuccess =
                                host_url1
                                //"localhost:8088"
                                + "/api/dps/result?action=paymentSuccess&orderId=" + orderId;

            //get order total
            var order = _context.Orders.Where(o => o.Id == Convert.ToInt32(orderId))
                        .Join(_context.Invoices,
                                o => o.InvoiceNumber,
                                i => i.InvoiceNumber,
                                (o, i) => new { o.InvoiceNumber, o.Id, Total = i.Total ?? 0 }).FirstOrDefault();
            decimal orderAmount = 0;
            if (order != null)
                orderAmount = order.Total;
            else
                return BadRequest();

            PxPay WS = new PxPay(sServiceUrl, PxPayUserId, PxPayKey);
            RequestInput input = new RequestInput();
            input.AmountInput = Math.Round(orderAmount, 2).ToString();
            input.CurrencyInput = "NZD";
            input.MerchantReference = orderId;
            input.TxnType = "Purchase";
            input.UrlFail = sReturnUrlFail;
            input.UrlSuccess = sReturnUrlSuccess;
            input.TxnData1 = returnUrl;

            Guid newOrderId = Guid.NewGuid();
            input.TxnId = newOrderId.ToString().Substring(0, 16);
            RequestOutput output = WS.GenerateRequest(input);
            if (output.valid == "1")
            {
                var result = output.Url;
                return Ok(result);
            }

            return NotFound();
        }
    }
}
