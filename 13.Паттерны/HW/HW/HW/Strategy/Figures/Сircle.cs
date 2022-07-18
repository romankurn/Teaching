using System;

namespace HW.Strategy
{
	public class Сircle : IFigure
	{
		public int Radius { get; private set; }

		public string Name { get; }

		public Сircle(int radius)
		{
			Radius = radius;
			Name = "Сircle";
		}

		public double CalculateArea()
		{
			return Math.PI * Radius * Radius;
		}
	}
}
