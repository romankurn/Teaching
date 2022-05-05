using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
	internal class FibonachaIterative : IFibonacha
	{
		public int GetFibonacciMember(int n)
		{
			var previous = 1;
			var previousprevious = 0;
			var current = 0;

			if (n == 1)
				return previousprevious;

			if (n == 2)
				return previous;

			for (int i = 2; i < n; i++)
			{
				current = previous + previousprevious;
				previousprevious = previous;
				previous = current;
			}

			return current;
		}
	}
}
