using ArtWorkshop.Service.Autorization;
using ArtWorkshop.Service.Exceptions.User;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ArtWorkshop.Service.Controllers
{
	public class Controller : ControllerBase
	{
		protected OkObjectResult Ok<T>(T result)
		{
			return new OkObjectResult(result);
		}

		protected void Autorize(int userId, string role)
		{
			var now = DateTime.Now;

			if (AutorizedUserStorage.Users.TryGetValue(userId, out var lastActivity))
			{
				lastActivity.LastActivityTime = now;

				AutorizedUserStorage.Users.TryUpdate(userId, lastActivity, lastActivity);
			}
			else
			{
				AutorizedUserStorage.Users.TryAdd(userId, new LastActivity { Role = role, LastActivityTime = now });
			}
		}

		protected void LogOut(int userId)
		{
			if (AutorizedUserStorage.Users.TryGetValue(userId, out var value))
			{
				AutorizedUserStorage.Users.TryRemove(userId, out value);
			}
			else
			{
				throw new UserNotFoundException();
			}
		}
	}
}
