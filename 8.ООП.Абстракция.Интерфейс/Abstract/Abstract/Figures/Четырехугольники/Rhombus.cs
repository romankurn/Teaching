using System;
using System.Diagnostics;

namespace Abstract
{
	public class Rhombus : Parallelogram
	{
		public double A => _side1;
		public double Alpha => _alpha;

		public Rhombus()
		{

		}
		public Rhombus(double side1, double alpha) : base(side1, side1, alpha)
		{

		}

		public override double GetSquare()
		{
			Debug.WriteLine($"{GetType().Name}.GetSquare()");
			return _side1 * _side1 * Math.Sin(_alpha);
		}
	}
}
