using System;

namespace GenericTree
{
	public class InvalidCoordinatesException : Exception
	{
		public InvalidCoordinatesException() : base("Enter valid coordinates")
		{

		}
	}
}
