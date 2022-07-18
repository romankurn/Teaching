using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace ArtWorkshop.Service.Autorization
{
	public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
	{
		private readonly string[] _roles;
		public CustomAuthorizeAttribute(params string[] roles)
		{
			_roles = roles;
		}
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (context.HttpContext.Request.Headers.TryGetValue("userId", out var value))
			{
				var now = DateTime.Now;

				var userId = int.Parse(value.First());

				if (AutorizedUserStorage.Users.TryGetValue(userId, out var lastActivity))
				{
					if (_roles.Any() && !_roles.Contains(lastActivity.Role))
					{
						context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
						return;
					}

					if (lastActivity.LastActivityTime.AddMinutes(AutorizedUserStorage.ExpiredTimeMinutes) < DateTime.Now)
					{
						context.Result = new UnauthorizedResult();
						return;
					}

					lastActivity.LastActivityTime = now;
					AutorizedUserStorage.Users.TryUpdate(userId, lastActivity, lastActivity);
				}
				else
				{
					context.Result = new UnauthorizedResult();
				}
			}
			else
			{
				context.Result = new UnauthorizedResult();
			}
		}
	}
}
