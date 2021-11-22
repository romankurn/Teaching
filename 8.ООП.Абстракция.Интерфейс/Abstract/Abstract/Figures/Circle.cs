using System;

namespace Abstract
{
	public class Circle : IShape
	{
		public double Radius { get; private set; }

		public Circle()
		{

		}

		public Circle(double radius)
		{
			Radius = radius;
		}
		public double GetPerimeter()
		{
			return 2 * Math.PI * Radius;
		}

		public double GetSquare()
		{
			return Math.PI * Radius * Radius;
		}
	}
}
