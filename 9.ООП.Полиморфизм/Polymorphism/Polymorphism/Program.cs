using DynamicMenu;
using System;
using System.Linq;

namespace Polymorphism
{
	class Program
	{
		private static University _university = new University(new StudentCollectionWrapper());

		static void Main(string[] args)
		{
			Start.Beginning();
		}
	}
}