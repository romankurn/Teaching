using System;

namespace ArtWorkshop.Service.Exceptions.User
{
	public class UserWithSameEmailAlreadyExistsException : Exception
	{
		public UserWithSameEmailAlreadyExistsException() : base()
		{

		}
	}
}
