using DynamicMenu;
using OOP1;
using System;


namespace GenericTree.Actions
{
	public class CreatePointAction : IAction
	{
		public void Execute()
		{
			var point = GetPoint();

			var item = new Inventory<Point>(InventoryType.Item, item: point);
			Floor.floor.Push(item);
		}

		public static Point GetPoint()
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
