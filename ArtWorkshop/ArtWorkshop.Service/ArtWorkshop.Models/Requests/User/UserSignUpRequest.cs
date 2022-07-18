
using ArtWorkshop.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace ArtWorkshop.Models.Requests.User
{
	public class UserSignUpRequest
	{
		[EmailAddress(ErrorMessage = "Invalid email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password must be passed")]
		[MinLength(8, ErrorMessage = "Password must contain minimum 8 symbols")]
		[MaxLength(64, ErrorMessage = "Password max length must not be grather than 64 symbols")]
		[Password(ErrorMessage = "Password must contain digit, capital letter, lower case letter and not contain white space")]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "Password are not equal")]
		public string PasswordConfirm { get; set; }

		[Required(ErrorMessage = "FirstName must be passed")]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "SecondName must be passed")]
		[StringLength(50)]
		public string SecondName { get; set; }
	}
}
