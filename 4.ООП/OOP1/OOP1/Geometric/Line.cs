using System;

namespace OOP1
{
	public class Line
	{
		private Point _point1;
		
		public Point Point2 { get; set; }

		public double Length => Math.Sqrt(Math.Pow(_point1.X - Point2.X, 2) + Math.Pow(_point1.Y - Point2.Y, 2));

		public Line()
		{
			_point1 = new Point();
			Point2 = new Point();
		}

		public Line(Point point1, Point point2)
		{
			_point1 = point1;
			Point2 = point2;
		}

		public static bool operator >(Line line1, Line line2)
		{
			return line1.Length > line2.Length;			
		}

		public static bool operator <(Line line1, Line line2)
		{
			return line1.Length < line2.Length;
		}

	}

}
