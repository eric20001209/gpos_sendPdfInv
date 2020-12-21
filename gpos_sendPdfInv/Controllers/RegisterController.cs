using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eCommerce_API.Dto;
using gpos_sendPdfInv.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gpos_sendPdfInv.Controllers
{
	[Authorize]
	[Route("api/userRegister")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly admingposContext _context;
		public RegisterController(admingposContext context)
		{
			_context = context;
		}

        [AllowAnonymous]
        [HttpPost("MD5")]
        public async Task<IActionResult> Register([FromBody] RegisterDto newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Card newCard = new Card();

            //check email exists or not!
            var email = newUser.email;
            bool hasemail = _context.Cards.Any(e => e.Email == email);
            var errorMsg = new { error = "Sorry, this email exists already!!!" };
            if (hasemail)
                return BadRequest(errorMsg.error);
            var password = newUser.password;
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            string md5password = sBuilder.ToString().ToUpper();
            newCard.Name = newUser.name;
            newCard.Email = newUser.email;
            newCard.Password = md5password; //newUser.password;
            newCard.Type = 6;// newUser.type;
            newCard.AccessLevel = 10;// newUser.accesslevel;

            await _context.Cards.AddAsync(newCard);
            await _context.SaveChangesAsync();
            return Ok(
                new { newCard.Name, newCard.Email, newCard.Password, newCard.Type, newCard.AccessLevel }
                );
        }
    }
}
