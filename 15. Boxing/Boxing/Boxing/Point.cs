using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing
{
	internal struct Point : IChangePoint
	{
		private int _a, _b;

		public Point(int a, int b)
		{
			_a = a;
			_b = b;
		}

		public override string ToString()
		{
			return $"({_a}, {_b})";
		}

		public void Change(int a, int b)
		{
			_a = a;
			_b = b;
		}

		public override bool Equals(object obj)
		{
			//if (obj == null)
			//	return false;

			//var pointObj = obj as Point?;

			//return pointObj?._a == _a && pointObj?._b == _b;
			return true;
		}

		public override int GetHashCode()
		{
			return 1;
		}
	}
}
