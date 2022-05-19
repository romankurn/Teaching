namespace HW.Strategy
{
	public class Trapezoid : IFigure
	{
		public int BaseA { get; private set; }

		public int BaseB { get; private set; }

		public int Height { get; private set; }

		public string Name { get; }

		public Trapezoid(int baseA, int baseB, int height)
		{
			BaseA = baseA;
			BaseB = baseB;
			Height = height;
			Name = "Trapezoid";
		}

		public double CalculateArea()
		{
			return ((BaseA + BaseB) / 2) * Height;
		}
	}
}
