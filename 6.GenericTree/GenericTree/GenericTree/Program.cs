using OOP1;
using System;
using System.Collections.Generic;

namespace GenericTree
{
	class Program
	{
		static void Main(string[] args)
		{
			var floor = new Inventory<Point>(InventoryType.Box);

			//TODO: Обернуть в обработчик исключений
			var exit = false;
			while (true)
			{
				Console.WriteLine("Choose action:");
				Console.WriteLine("1: Create box");
				Console.WriteLine("2: Create item");
				Console.WriteLine("3: Move item");
				Console.WriteLine("4: Move box");
				Console.WriteLine("0: Close");
				var option = Convert.ToByte(Console.ReadLine());

				Console.WriteLine();
				switch (option)
				{
					case 1:
						//TODO set box name
						var box = new Inventory<Point>(InventoryType.Box, "boxName");
						floor.Push(box);
	
						break;

					case 2:

						var point = GetPoint();

						var item = new Inventory<Point>(InventoryType.Item, item: point);
						floor.Push(item);

						break;

					case 3:

						var soursePoint = GetPoint();

						var targetBox = floor.Find("boxName");
						var sourceId = floor.Find(soursePoint);
						floor.Move(targetBox.Id, sourceId.Value);

						break;

					case 4:

						var sourseBox = floor.Find("sourseBoxName");
						var targetBox2 = floor.Find("targetBoxName");

						floor.Move(targetBox2.Id, sourseBox.Id);

						break;

					case 0:
						exit = true;
						break;
				}

				if (exit)
					break;
			}
		}

		static Point GetPoint()
		{
			Console.WriteLine("Enter cordinates");
			var x = Convert.ToDouble(Console.ReadLine());
			var y = Convert.ToDouble(Console.ReadLine());
			return new Point(x, y);
		}
	}
}

//var exit = false;
//while (true)
//{
//	Console.WriteLine("Choose action:");
//	Console.WriteLine("1: Add");
//	Console.WriteLine("2: Edit");
//	Console.WriteLine("3: Print");
//	Console.WriteLine("0: Close");
//	var option = Convert.ToByte(Console.ReadLine());

//	switch (option)
//	{
//		case 1:
//			break;
//		case 0:
//		default:
//			exit = true;
//			break;
//	}

//	if (exit)
//		break;
//}
