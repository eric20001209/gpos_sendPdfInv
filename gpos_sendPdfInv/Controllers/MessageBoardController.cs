﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce_API_RST.Dto;
using gpos_sendPdfInv.Entities;
using gpos_sendPdfInv.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace gpos_sendPdfInv.Controllers
{
	[Authorize]
	[AllowAnonymous]
	[Route("api/message")]
	[ApiController]
	public class MessageBoardController : ControllerBase
	{
		private readonly iMailService _mail;
		private readonly admingposContext _context;
		private readonly IConfiguration _config;
		public MessageBoardController(iMailService mail, admingposContext context, IConfiguration config)
		{
			_mail = mail;
			_context = context;
			_config = config;
		}

		[HttpPost]
		public async Task<IActionResult> sendMessage([FromBody] MessageDto message)
		{

			if (!ModelState.IsValid)
				return BadRequest(JsonConvert.SerializeObject(ModelState.Values.Select(e => e.Errors).ToList()));
			try
			{
				var receiverEmail = _config["ContactEmail"];
				/* add to messageboard table*/
				var messageboard = new MessageBoard()
				{
					Name = message.Name,
					Subject = message.Subject,
					Content = message.Content,
					Email = message.Email
				};
				await _context.MessageBoards.AddAsync(messageboard);
				//update database
				await _context.SaveChangesAsync();

				/* send email to supplier */
				var subject = message.Subject;
				var content = "Name :" + message.Name + "<br/>";
				content += "Contact Email : " + message.Email + "<br/><br/>";
				content += message.Content;
				await _mail.sendEmail(receiverEmail, subject, content, null);

				return Ok();
			}
			catch (Exception)
			{

				throw;
			}

		}
	}
}
