using System;
using DynamicMenu;
using OOP1;

namespace GenericTree
{
	public class MoveBoxAction : IAction
	{
		public IOutputParams Execute(IInputParams inputParams = null)
		{
			Console.Write("Enter sourse box name: ");
			var sourseBoxName = Console.ReadLine();
			Console.Write("Enter target box name: ");
			var targetBoxName = Console.ReadLine();

			var sourseBox = Floor.floor.FindBox(sourseBoxName);
			var targetBox2 = Floor.floor.FindBox(targetBoxName);

			Floor.floor.Move(targetBox2.Id, sourseBox.Id);

			return null;
		}
	}
}
