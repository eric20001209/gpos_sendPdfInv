using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gpos_sendPdfInv.Entities;

namespace gpos_sendPdfInv.Controllers
{
	[Authorize]
	[AllowAnonymous]
	[Route("api/category")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly admingposContext _context;
		public CategoryController(admingposContext context)
		{
			_context = context;
		}

        [HttpGet()]
        public IActionResult categoryList([FromQuery] string cat, [FromQuery] string scat, [FromQuery] string sscat)
        {
            var list = _context.CodeRelations
                .Where(c => c.IsWebsiteItem == true && c.OnLineRetail == true && c.Skip == false)
                //              .Where(c=>c.Skip == false)
                .Where(c => !String.IsNullOrEmpty(c.Cat))
                .Where(c => cat != null ? c.Cat == cat : true)
                .Where(c => scat != null ? c.SCat == scat : true)
                .Where(c => sscat != null ? c.SsCat == scat : true)
                .Select(c => new
                {
                    c.Cat,
                    c.SCat,
                    c.SsCat
                }).Distinct().ToList();

            return Ok(list);
        }
    }
}
