using System;

namespace OOP1
{
	public class Point
	{
		//Fields
		private double _x;

		//Properties
		public double X 
		{ 
			get { return _x; }
			set { _x = value; }
		}

		public double Y { get; set; }

		/// <summary>
		/// Конструктор без параметров
		/// </summary>
		public Point()
		{
			_x = 0;
			Y = 0;
		}

		/// <summary>
		/// Конструктор с параметрами
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Point(double x, double y)
		{
			_x = x;
			Y = y;
		}

		public void Show()
		{
			Console.WriteLine($"({_x}; {Y})");
		}

		public static bool operator >(Point point1, Point point2)
		{
			return point1.X == point2.X ? point1.Y > point2.Y : point1.X > point2.X;
		}

		public static bool operator <(Point point1, Point point2)
		{
			return point1.X == point2.X ? point1.Y < point2.Y : point1.X < point2.X;
		}

		public static bool operator ==(Point point1, Point point2)
		{
			return point1.X == point2.X && point1.Y == point2.Y;
		}

		public static bool operator !=(Point point1, Point point2)
		{
			return point1.X != point2.X || point1.Y != point2.Y;
		}

		public static Point operator + (Point point1, Point point2)
		{
			return new Point(point1.X + point2.X, point1.Y + point2.Y);
		}
	}
}
