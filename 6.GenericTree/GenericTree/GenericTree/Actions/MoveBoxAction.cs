using DynamicMenu;
using System;

namespace GenericTree.Actions
{
	public class MoveBoxAction : IAction
	{
		public void Execute()
		{
			Console.Write("Enter sourse box name: ");
			var sourseBoxName = Console.ReadLine();
			Console.Write("Enter target box name: ");
			var targetBoxName = Console.ReadLine();

			var sourseBox = Floor.floor.FindBox(sourseBoxName);
			var targetBox2 = Floor.floor.FindBox(targetBoxName);

			Floor.floor.Move(targetBox2.Id, sourseBox.Id);
		}
	}
}
