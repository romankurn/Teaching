using System;
using System.Diagnostics;

namespace Abstract
{
	internal class Trapezoid : Quad
	{
		protected double _alpha;

		public double A => _side1;
		public double B => _side2;
		public double C => _side3;
		public double Alpha => _alpha;

		public Trapezoid()
		{

		}

		public Trapezoid(double side1, double side2, double side3, double alpha) : base(side1, side2, side3, side3)
		{
			_alpha = alpha;
		}

		public override double GetSquare()
		{
			Debug.WriteLine($"{GetType().Name}.GetSquare()");

			var p = (_side1 + _side2 + 2 * _side3) / 2;
			return Math.Sqrt((p - _side1) * (p - _side2) * Math.Pow(p - _side3, 2));
		}
	}
}
