using System.Diagnostics;

namespace Abstract
{
	public class Square : Rectangle
	{
		public double A => _side1;

		public Square()
		{

		}

		public Square(double side1) : base(side1, side1)
		{

		}

		public override double GetSquare()
		{
			Debug.WriteLine($"{GetType().Name}.GetSquare()");
			return _side1 * _side1;
		}
	}
}
