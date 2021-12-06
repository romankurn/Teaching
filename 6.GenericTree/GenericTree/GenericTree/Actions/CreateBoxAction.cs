using DynamicMenu;
using OOP1;
using System;

namespace GenericTree.Actions
{
	public class CreateBoxAction : IAction
	{
		public void Execute()
		{
			Console.WriteLine("Enter box name");
			var boxName = Console.ReadLine();
			var box = new Inventory<Point>(InventoryType.Box, boxName);
			Floor.floor.Push(box);
		}
	}
}
