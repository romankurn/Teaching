using System;
using DynamicMenu;
using OOP1;

namespace GenericTree.Actions
{
	public class CreateBoxAction : IAction
	{
		
		public IOutputParams Execute(IInputParams inputParams = null)
		{
			Console.WriteLine("Enter box name");
			var boxName = Console.ReadLine();
			var box = new Inventory<Point>(InventoryType.Box, boxName);
			Floor.floor.Push(box);

			return null;
		}
	}
}
