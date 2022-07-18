using ArtWorkshop.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtWorkshop.Client
{
	public class ArtWorkshopException : Exception
	{
		public ErrorCode ErrorCode { get; private set; } 

		public ArtWorkshopException(string errorCode) : base(errorCode)
		{
			ErrorCode = Enum.Parse<ErrorCode>(errorCode);
		}
	}
}
