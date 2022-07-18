using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Prototype
{
	public class Implementation
	{
		public static void Execute()
		{
			//var rectangle1 = new Rectangle() { Height = 10, Width = 5 };
			//var rectangle2 = rectangle1.Clone() as Rectangle;
			

			//rectangle1.Width = 20;

			//Console.WriteLine(rectangle1);
			//Console.WriteLine(rectangle2);

			var circle1 = new Circle() { Point = new Point() { X = 1, Y = 1 }, Radius = 1};
			var circle2 = circle1.DeepClone() as Circle;



			circle1.Point.X =  2;
			circle1.Point.Y = 2;
			circle1.Radius = 2;

			Console.WriteLine(circle1); // 2 2 2
			Console.WriteLine(circle2); // 1 1 1
		}
	}
}
