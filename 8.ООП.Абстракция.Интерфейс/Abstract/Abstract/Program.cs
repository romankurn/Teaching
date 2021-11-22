using System;
using System.Diagnostics;

namespace Abstract
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.ReadKey();
		}

		static IShape GetShape(string type)
		{
			switch (type)
			{
				case "Parallelogram":
					return new Parallelogram();

				case "Rectangle":
					return new Rectangle();

				case "Rhombus":
					return new Rhombus();

				case "Square":
					return new Square();

				case "Trapezoid":
					return new Trapezoid();

				case "Circle":
					return new Circle();

					default: throw new ArgumentException();
			}
		}
	}
}

//var par = new Parallelogram(1, 2, 60);
//var rec = new Rectangle(1, 2);
//var romb = new Rhombus(2, 30);
//var square = new Square(2);
//var trap = new Trapezoid(1, 2, 3, 60);
//var circle = new Circle(5);

//PaperList.Shapes.Add(par);
//PaperList.Shapes.Add(rec);
//PaperList.Shapes.Add(romb);
//PaperList.Shapes.Add(square);
//PaperList.Shapes.Add(trap);
//PaperList.Shapes.Add(circle);

//double totalSquare = 0;

//foreach (var shape in PaperList.Shapes)
//{
//	totalSquare += shape.GetSquare();
//}
