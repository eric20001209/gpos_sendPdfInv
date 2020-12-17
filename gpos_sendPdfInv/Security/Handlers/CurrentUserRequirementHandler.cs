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
	public class CurrentUserRequirementHandler : AuthorizationHandler<CurrentUserRequirement>
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public CurrentUserRequirementHandler(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CurrentUserRequirement requirement)
		{
//			var hasUser = context.User.HasClaim(c => c.Type == Constants.END_USER && c.Value == Constants.TRUE);
			var user = context.User.Claims.FirstOrDefault(c => c.Type == Constants.USER_ID);
			if (user == null)
			{
				context.Fail();
				return Task.CompletedTask;
			}
			var useridFromContext = context.User.Claims.FirstOrDefault(c => c.Type == Constants.USER_ID).Value;
			var useridFromRequest = _httpContextAccessor.HttpContext.Request.RouteValues["userid"].ToString();
//			if (hasUser && (useridFromContext == useridFromRequest))
			if (useridFromContext == useridFromRequest)
			{
				context.Succeed(requirement);
			}
			//if (_isSuperAdmin.Handle(context))
			//{
			//	context.Succeed(requirement);
			//}
			return Task.CompletedTask;

		}
	}
}
