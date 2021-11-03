using ObjectSaver;
using OOP1;
using System;

namespace GenericTree
{
	class Program
	{
		private static Inventory<Point> floor;
		private const string fileName = "boxes.txt";

		static void Main(string[] args)
		{
			floor = new Inventory<Point>(InventoryType.Box, "floor");

			//TODO: Обернуть в обработчик исключений
			var exit = false;


			while (true)
			{
				try
				{
					Console.WriteLine();
					Console.WriteLine("Choose action:");
					Console.WriteLine("1: Create box");
					Console.WriteLine("2: Create item");
					Console.WriteLine("3: Move ...");
					Console.WriteLine("4: Pull");
					Console.WriteLine("5: Scan");
					Console.WriteLine("6: Save");
					Console.WriteLine("7: Load");
					Console.WriteLine("0: Close");
					var option = Convert.ToByte(Console.ReadLine());


					Console.WriteLine();
					switch (option)
					{
						case 1:
							CreateBox();

							break;

						case 2:
							CreatePoint();

							break;

						case 3:
							Console.WriteLine("1: Move item");
							Console.WriteLine("2: Move box");

							var option2 = Convert.ToByte(Console.ReadLine());
							switch (option2)
							{
								case 1:
									MoveItem();

									break;

								case 2:
									MoveBox();

									break;
							}

							break;

						case 4:

							var point = GetPoint();
							point = floor.FindItem(point);

							Console.WriteLine($"{(point != null ? point : "nothing")} was found");

							break;

						case 5:
							floor.Scan();

							break;

						case 6:

							File<Inventory<Point>>.Save(fileName, floor);

							break;

						case 7:

							floor  = File<Inventory<Point>>.GetItemFromFile(fileName);

							break;

						case 0:
							exit = true;
							break;
					}

					if (exit)
						break;
				}
				catch (FormatException)
				{
					Console.WriteLine("Enter correct menu option");
				}
				catch (Exception e)
				{
					var t = e.GetType();
					Console.WriteLine(e.Message);
				}
			

			}

		}

		static void MoveBox()
		{
			Console.Write("Enter sourse box name: ");
			var sourseBoxName = Console.ReadLine();
			Console.Write("Enter target box name: ");
			var targetBoxName = Console.ReadLine();

			var sourseBox = floor.FindBox(sourseBoxName);
			var targetBox2 = floor.FindBox(targetBoxName);

			floor.Move(targetBox2.Id, sourseBox.Id);
		}

		static void MoveItem()
		{
			var soursePoint = GetPoint();

			Console.Write("Enter box name: ");
			var boxName = Console.ReadLine();

			var targetBox = floor.FindBox(boxName);
			var sourceId = floor.GetItemId(soursePoint);
			floor.Move(targetBox.Id, sourceId.Value);
		}

		static void CreateBox()
		{
			Console.WriteLine("Enter box name");
			var boxName = Console.ReadLine();
			var box = new Inventory<Point>(InventoryType.Box, boxName);
			floor.Push(box);
		}

		static void CreatePoint()
		{
			var point = GetPoint();

			var item = new Inventory<Point>(InventoryType.Item, item: point);
			floor.Push(item);
		}

		static Point GetPoint()
		{
			try
			{
				Console.Write("Enter cordinates: ");
				var coordinates = Console.ReadLine();
				var x = double.Parse(coordinates.Split(" ")[0]);
				var y = double.Parse(coordinates.Split(" ")[1]);
				return new Point(x, y);
			}
			catch
			{
				throw new InvalidCoordinatesException();
			}
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
