using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
	internal class FibonachaRecursive : IFibonacha
	{
		public int GetFibonacciMember(int n)
		{
			if (n == 2)
				return 1;

			if (n == 1)
				return 0;

			var n_1 = GetFibonacciMember(n - 1);
			var n_2 = GetFibonacciMember(n - 2);

			return n_1 + n_2;
		}
	}
}
