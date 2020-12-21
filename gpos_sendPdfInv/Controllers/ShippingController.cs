using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce_API.Dto;
using gpos_sendPdfInv.Entities;
using gpos_sendPdfInv.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace gpos_sendPdfInv.Controllers
{
	[Authorize]
	[Route("api/shipping")]
	[ApiController]
	[Authorize(Policy = Constants.CURRENT_USER)]

	public class ShippingController : ControllerBase
	{
		private readonly admingposContext _context;
		public ShippingController(admingposContext context)
		{
			_context = context;
		}

        [HttpGet("{userId}")]
        public IActionResult shippingAddressList(int userId)
        {
            var shiptoList = _context.Cards.Where(c => c.MainCardId == userId)
                .Select(c => new ShippingToDto
                {
                    id = c.Id,
                    name = c.Name,
                    company = c.Company,
                    address1 = c.Address1,
                    address2 = c.Address2,
                    address3 = c.Address3,
                    city = c.City,
                    country = c.Country,
                    zip = c.Zip,
                    phone = c.Phone,
                    contact = c.Contact,
                    note = c.Note
                }).ToList();
            return Ok(shiptoList);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> addShippingAddress(int userId, [FromBody] AddShippingDto newShipping)
        {
            var shippingToAdd = new Card();
            shippingToAdd.MainCardId = userId;
            shippingToAdd.Name = newShipping.name;
            shippingToAdd.Company = newShipping.company;
            shippingToAdd.Address1 = newShipping.address1;
            shippingToAdd.Address2 = newShipping.address2;
            shippingToAdd.Address3 = newShipping.address3;
            shippingToAdd.City = newShipping.city;
            shippingToAdd.Country = newShipping.country;
            shippingToAdd.Phone = newShipping.phone;
            shippingToAdd.Contact = newShipping.contact;
            shippingToAdd.Zip = newShipping.zip;
            shippingToAdd.Note = newShipping.note;
            shippingToAdd.Email = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            try
            {
                await _context.AddAsync(shippingToAdd);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return Ok();
        }

        [HttpDelete("del/{userId}/{id}")]
        public async Task<IActionResult> deleteShippingAddress(int userId, int id)
        {
            var shippingToDelete = _context.Cards.Where(c => c.Id == id && c.MainCardId == userId).FirstOrDefault();

            if (shippingToDelete == null)
                return NotFound();
            try
            {
                _context.Cards.Remove(shippingToDelete);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }

            return NoContent();
        }

        [HttpPatch("patch/{userId}/{id}")]
        public async Task<IActionResult> updateShippingAddress(int userId, int id, [FromBody] JsonPatchDocument<UpdateShippingDto> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest();
            var shippingAddressToUpdate = _context.Cards.Where(c => c.Id == id && c.MainCardId == userId).FirstOrDefault();
            if (shippingAddressToUpdate == null)
                return NotFound();

            var shippingToPatch = new UpdateShippingDto()
            {
                name = shippingAddressToUpdate.Name,
                company = shippingAddressToUpdate.Company,
                address1 = shippingAddressToUpdate.Address1,
                address2 = shippingAddressToUpdate.Address2,
                address3 = shippingAddressToUpdate.Address3,
                city = shippingAddressToUpdate.City,
                country = shippingAddressToUpdate.Country,
                phone = shippingAddressToUpdate.Phone,
                contact = shippingAddressToUpdate.Contact,
                note = shippingAddressToUpdate.Note,
                zip = shippingAddressToUpdate.Zip
            };

            patchDoc.ApplyTo(shippingToPatch, ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            shippingAddressToUpdate.Name = shippingToPatch.name;
            shippingAddressToUpdate.Company = shippingToPatch.company;
            shippingAddressToUpdate.Address1 = shippingToPatch.address1;
            shippingAddressToUpdate.Address2 = shippingToPatch.address2;
            shippingAddressToUpdate.Address3 = shippingToPatch.address3;
            shippingAddressToUpdate.City = shippingToPatch.city;
            shippingAddressToUpdate.Country = shippingToPatch.country;
            shippingAddressToUpdate.Phone = shippingToPatch.phone;
            shippingAddressToUpdate.Contact = shippingToPatch.contact;
            shippingAddressToUpdate.Note = shippingToPatch.note;
            shippingAddressToUpdate.Zip = shippingToPatch.zip;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
