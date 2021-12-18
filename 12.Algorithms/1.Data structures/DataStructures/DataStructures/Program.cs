using DataStructures.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var list = new List<int> { 1, 2, 3 };

			list.Any(); // true
			list.Any(t => t > 0);
		}
	}
}
