using System;

namespace HW.Strategy
{
	public class Rectangle : IFigure
	{
		public int Height { get; private set; }

		public int Width { get; private set; }

		public string Name { get; }

		public Rectangle(int height, int width)
		{
			Height = height;
			Width = width;
			Name = "Rectangle";
		}

		public double CalculateArea()
		{
			return Height * Width;
		}
	}
}
