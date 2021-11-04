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

		public Point(Point copyingObject)
		{
			_x = copyingObject._x;
			Y = copyingObject.Y;
		}

		public void Show()
		{
			Console.WriteLine($"({_x}; {Y})");
		}

		public override bool Equals(object obj)
		{
			var point = obj as Point;

			return point.X == X && point.Y == Y;
		}

		public override string ToString()
		{
			return $"({X}; {Y})";
		}

		public static bool operator >(Point point1, Point point2)
		{
			return point1.X == point2.X ? point1.Y > point2.Y : point1.X > point2.X;
		}

		public static bool operator <(Point point1, Point point2)
		{
			return point1.X == point2.X ? point1.Y < point2.Y : point1.X < point2.X;
		}

		//public static bool operator ==(Point point1, Point point2)
		//{
		//	return point1.X == point2.X && point1.Y == point2.Y;
		//}

		//public static bool operator !=(Point point1, Point point2)
		//{
		//	return point1 != null && point2 != null && point1.X != point2.X || point1.Y != point2.Y;
		//}

		public static Point operator + (Point point1, Point point2)
		{
			return new Point(point1.X + point2.X, point1.Y + point2.Y);
		}
	}
}
