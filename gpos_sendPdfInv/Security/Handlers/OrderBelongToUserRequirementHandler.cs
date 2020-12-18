using gpos_sendPdfInv.Entities;
using gpos_sendPdfInv.Security.Requirements;
using gpos_sendPdfInv.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gpos_sendPdfInv.Security.Handlers
{
	public class OrderBelongToUserRequirementHandler : AuthorizationHandler<OrderBelongToUserRequirement>
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly admingposContext _context;
		public OrderBelongToUserRequirementHandler(IHttpContextAccessor httpContextAccessor, admingposContext context)
		{
			_httpContextAccessor = httpContextAccessor;
			_context = context;
		}
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OrderBelongToUserRequirement requirement)
		{
			var user = context.User.Claims.FirstOrDefault(c => c.Type == Constants.USER_ID);
			if (user == null)
			{
				context.Fail();
				return Task.CompletedTask;
			}
			var useridFromContext = context.User.Claims.FirstOrDefault(c => c.Type == Constants.USER_ID).Value;
			var orderidFromRequest = _httpContextAccessor.HttpContext.Request.RouteValues["orderId"].ToString();
			var hasOrder = _context.Orders.Any(o => o.Id.ToString() == orderidFromRequest && o.CardId.ToString() == useridFromContext);
			if (hasOrder)
			{
				context.Succeed(requirement);
			}
			return Task.CompletedTask;
		}
	}
}
