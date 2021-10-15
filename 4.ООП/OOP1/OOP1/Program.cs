using System;

namespace OOP1
{
	/// <summary>
	/// 1. https://metanit.com/sharp/tutorial/3.1.php
	/// 2. https://metanit.com/sharp/tutorial/2.13.php - рассказать отличие от классов
	/// 3. https://metanit.com/sharp/tutorial/2.16.php
	/// 4. https://metanit.com/sharp/tutorial/3.4.php
	/// 5. https://metanit.com/sharp/tutorial/3.3.php
	/// 6. https://metanit.com/sharp/tutorial/3.36.php
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			var point1 = new Point(5, 10);
			var point2 = new Point(10, -10);
			//var point3 = point1 + point2;
			//point3.Show();

			//var a = point2 > point1;

			var line = new Line(point1, point2);
			var line2 = new Line(new Point(0, 0), new Point(3, -4));

			var length = line.Length;
			var length2 = line2.Length;



		}


	}
}
