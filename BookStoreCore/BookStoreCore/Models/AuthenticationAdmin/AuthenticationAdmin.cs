using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace BookStoreCore.AuthenticationAdmin
{
	public class AuthenticationAdminAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (context.HttpContext.Session.GetString("UserName") == null)
			{
				context.Result = new RedirectToRouteResult(
					new RouteValueDictionary
					{
						{"controller", "AccessAdmin" },
						{"action", "Login" }
					}
				);
			}
		}
	}
}


