using System;

namespace GenericTree
{
	public class ItemNullException : Exception
	{
		public ItemNullException() : base("Item cannot be null")
		{
			
		}
	}
}
