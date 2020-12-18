using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gpos_sendPdfInv.Entities;
using gpos_sendPdfInv.Services;
using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;

namespace gpos_sendPdfInv.Controllers
{
    [Authorize]
    [AllowAnonymous]
	[Route("api/invoice")]
	[ApiController]
	public class InvoiceController : ControllerBase
	{
		private ILogger<InvoiceController> _logger;
		private readonly admingposContext _context;
		private readonly IConfiguration _config;
		private readonly iMailService _mail;
		private IConverter _converter;
        private IInvoice _invoice;
		public InvoiceController(ILogger<InvoiceController> logger
									, admingposContext context
									, IConfiguration config
									, iMailService mail
									, IConverter converter
                                    , IInvoice invoice)
		{
			_logger = logger;
			_context = context;
			_config = config;
			_mail = mail;
			_converter = converter;
            _invoice = invoice;
		}

		[HttpGet("pdf/{invoice_number}")]
		public IActionResult createPDF(int invoice_number, string gst)
		{
            PdfInvoiceTemplateGenerator pdfGenerator = new PdfInvoiceTemplateGenerator(_invoice);
            try
            {
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF Report",
                    Out = _config["PdfPath"] + invoice_number + ".pdf"
                };
                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = pdfGenerator.GetHTMLString(invoice_number),
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(_config["PdfPath"], "Assets", "styles.css") },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true }
                };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                _converter.Convert(pdf);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }

            return Ok("Successfully created PDF document.");
        }

        [HttpGet("send/{invoice_number}/{customerEmail}")]
        public async Task<IActionResult> sendPdf(int invoice_number, string customerEmail)
        {
			try
			{
                string host = "https://" + HttpContext.Request.Host;// _config["ApiUrl"];
                var currentSite = _config["CurrentSite"];
				try
				{
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(host);

                        //var responseTask = client.GetAsync(currentSite + "/api/invoice/pdf/" + invoice_number);
                        var responseTask = client.GetAsync( "/api/invoice/pdf/" + invoice_number);
                        responseTask.Wait();
                        var getResult = responseTask.Result;
                        if (getResult.IsSuccessStatusCode)
                        {
                            //send order to customer by email
                            var myAttachment = new Attachment(_config["PdfPath"] + invoice_number + ".pdf");
                            await _mail.sendEmail(customerEmail, "Invoice", "DoNotReply! <br><br> Dear customer: <br>Thank you for your order from<a href='http://gpos.gposnz.com/'> gpos.gposnz.com</a><br> Your order invoice is in attachment.", myAttachment);
                            return Ok("invoice sent!");
                        }
                    }
                }
				catch (Exception ex)
				{
                    _logger.LogError(ex.Message + "\r\n" + $"Send email error.");
                    return BadRequest(ex.ToString());
				}

            }
			catch (Exception ex)
			{
                _logger.LogError(ex.Message + "\r\n" + $"Send email error.");
                return BadRequest(ex.ToString());
            }
            return BadRequest();
        }

	}
}
