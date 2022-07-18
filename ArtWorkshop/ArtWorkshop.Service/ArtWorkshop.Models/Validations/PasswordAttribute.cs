using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ArtWorkshop.Models.Validations
{
	public class PasswordAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			var stringValue = value as string;

			if(stringValue.Any(c => char.IsWhiteSpace(c)))
				return false;

			bool isDigit = false;
			bool isUppercase = false;
			bool isLowercase = false;

			foreach (var item in stringValue)
			{
				if(char.IsDigit(item))
					isDigit = true;

				if(char.IsLetter(item) && char.IsUpper(item))
					isUppercase = true;

				if(char.IsLetter(item) && char.IsLower(item))
					isLowercase = true;

				if (isDigit && isUppercase && isLowercase)
					return true;
			}

			return false;
		}
	}
}
