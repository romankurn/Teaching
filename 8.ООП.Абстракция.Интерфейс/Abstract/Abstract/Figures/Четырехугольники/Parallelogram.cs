using System;
using System.Diagnostics;

namespace Abstract
{
	public class Parallelogram : Quad
	{
		protected double _alpha;

		public double A => _side1;
		public double B => _side2;
		public double Alpha => _alpha;

		public Parallelogram()
		{

		}

		public Parallelogram(double side1, double side2, double alpha) : base(side1, side2, side1, side2)
		{
			_alpha = alpha;
		}

		public override double GetSquare()
		{
			Debug.WriteLine($"{GetType().Name}.GetSquare()");
			return _side1 * _side2 * Math.Sin(_alpha);
		}
	}
}
