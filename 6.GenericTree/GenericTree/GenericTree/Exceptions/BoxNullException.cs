using System;

namespace GenericTree
{
	public class BoxNullException : Exception
	{
		public BoxNullException() : base("Box is not found")
		{

		}
	}
}
