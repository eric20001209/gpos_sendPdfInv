using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using gpos_sendPdfInv.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace gpos_sendPdfInv.Controllers
{
	[Authorize]
	[AllowAnonymous]
	[Route("api/sync")]
	[ApiController]
	public class SyncController : ControllerBase
	{
		private readonly admingposContext _context;
		private readonly IConfiguration _config;
		public SyncController(admingposContext context, IConfiguration config)
		{
			_context = context;
			_config = config;
		}

		[HttpGet("branchId")]
		public async Task<IActionResult> getSyncItems(int branchId)
		{
			var syncPath = Path.Combine(_config["Sync:IniPath"], "sync.ini");

			return Ok();
		}
	}
}
