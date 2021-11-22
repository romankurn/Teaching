namespace Abstract
{
	public abstract class Quad : IShape
	{
		protected double _side1;
		protected double _side2;
		protected double _side3;
		protected double _side4;

		protected Quad()
		{

		}

		protected Quad(double side1, double side2, double side3, double side4)
		{
			_side1 = side1;
			_side2 = side2;
			_side3 = side3;
			_side4 = side4;
		}

		public double GetPerimeter()
		{
			return _side1 + _side2 + _side3 + _side4;
		}

		public abstract double GetSquare();
	}
}
