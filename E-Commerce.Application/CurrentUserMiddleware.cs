using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application
{
	public class CurrentUserMiddleware(RequestDelegate next)
	{
		public async Task Invoke(HttpContext context)
		{
			var user = context.User;
			if (user.Identity!.IsAuthenticated)
			{
				var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
				context.Items["UserId"] = userId;
			}

			await next(context);
		} 
	}
}
