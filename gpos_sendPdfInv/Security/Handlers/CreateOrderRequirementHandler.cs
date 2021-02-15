using gpos_sendPdfInv.Security.Requirements;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce_API.Dto;
using gpos_sendPdfInv.Services;

namespace gpos_sendPdfInv.Security.Handlers
{
	public class CreateOrderRequirementHandler : AuthorizationHandler<CreateOrderRequirement>
	{
		public CreateOrderRequirementHandler(CartDto cartInput)
		{

		}
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CreateOrderRequirement requirement)
		{
			var user = context.User.Claims.FirstOrDefault(c => c.Type == Constants.USER_ID);
			if (user == null)
			{
				context.Fail();
				return Task.CompletedTask;
			}
			var useridFromContext = context.User.Claims.FirstOrDefault(c => c.Type == Constants.USER_ID).Value;
			var useridFromDto = ""; // _httpContextAccessor.HttpContext.Request.RouteValues["userid"].ToString();
			if (useridFromContext == useridFromDto)
			{
				context.Succeed(requirement);
			}
			return Task.CompletedTask;
		}
	}
}
