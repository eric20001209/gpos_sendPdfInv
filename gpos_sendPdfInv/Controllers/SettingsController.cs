using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gpos_sendPdfInv.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gpos_sendPdfInv.Controllers
{
	[Authorize]
	[AllowAnonymous]
	[Route("api/ecom")]
	[ApiController]
	public class SettingsController : ControllerBase
	{
		private readonly admingposContext _context;
		public SettingsController(admingposContext context)
		{
			_context = context;
		}
		[HttpGet("banner")]
		public async Task<IActionResult> getEcomBanner()
		{
			var ecomBanners = await _context.EcomBanner.ToListAsync();
			return Ok(ecomBanners);
		}

		[HttpGet("setting")]
		public async Task<IActionResult> getEcomSetting()
		{
			var ecomSetting = await _context.EcomSetting.ToListAsync();
			return Ok(ecomSetting);
		}

		[HttpGet("topmenu")]
		public async Task<IActionResult> getEcomTopMenu()
		{
			var ecomTopMenu = await _context.EcomTopMenu.ToListAsync();
			return Ok(ecomTopMenu);
		}
	}
}
