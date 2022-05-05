using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
	public class Vehicle
	{
		private IMovable _transporte;

		public int Capacity { get; set; }

		public Vehicle(IMovable transporte, int capacity)
		{
			_transporte = transporte;
			Capacity = capacity;
		}

		public double Move(int distance)
		{
			return _transporte.Move(distance);
		}
	}
}
