using System;
using System.Linq;

namespace OOP1
{
	/// <summary>
	/// Массив точек
	/// в конструкторе без параметров - массив из двух точек
	/// в конструкторе с параметром - массив точек
	/// 
	/// 1) метод который считает суммарную длину   done
	/// 2) перегрузка + для добавления новой точки   done
	/// 3) длина между начальной и конечной точкой   done
	/// 4)* реализовать метод, который скажет, есть ли пересечения
	/// </summary>
	public class BrokenLine
	{
		public Point[] Points { get; set; }

		public BrokenLine() // если сделать изначально в поле public Point[] Points { get; set; } = new Point[2]; не получится ли тот же самый результат?
		{
			Points = new Point[2];
		}

		public BrokenLine(Point[] array)
		{
			Points = array;
		}

		public static BrokenLine operator +(BrokenLine brokenLine, Point point) // как работает "=" для объекторв классов?
		{
			var newPoints = new Point[brokenLine.Points.Length + 1];
			var counter = 0;

			foreach (var element in brokenLine.Points)
			{
				newPoints[counter++] = element;
			}
			newPoints[brokenLine.Points.Length] = point;

			var result = new BrokenLine(newPoints);
			return result;
		}

		//public static BrokenLine operator +(BrokenLine brokenLine, int length)
		//{
		//	//C.x = B.x + (B.x - A.x) / lenAB * length;
		//	//C.y = B.y + (B.y - A.y) / lenAB * length;
		//	return new BrokenLine();
		//}

		public double GetDistance()
		{
			var line = new Line(Points[0], Points.Last());
			return line.Length;
		}

		public double GetLength()
		{
			double length = 0;

			for (var i = 0; i < Points.Length - 1; i++)
			{
				var line = new Line(Points[i], Points[i + 1]);
				length += line.Length;
			}

			return length;
		}

	}
}
