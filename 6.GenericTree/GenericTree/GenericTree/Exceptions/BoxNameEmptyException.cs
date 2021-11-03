using System;

namespace GenericTree
{
	public class BoxNameEmptyException : Exception
	{
		public BoxNameEmptyException() : base("Box name expected")
		{

		}
	}
}
