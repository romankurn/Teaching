using System.Diagnostics;

namespace Abstract
{
	public class Rectangle : Parallelogram
	{
		public double A => _side1;
		public double B => _side2;

		public Rectangle()
		{

		}
		public Rectangle(double side1, double side2) : base(side1, side2, 90)
		{

		}

		public override double GetSquare()
		{
			Debug.WriteLine($"{GetType().Name}.GetSquare()");
			return _side1 * _side2;
		}
	}
}
