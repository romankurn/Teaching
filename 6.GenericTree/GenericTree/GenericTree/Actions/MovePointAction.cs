using DynamicMenu;
using System;

namespace GenericTree.Actions
{
	public class MovePointAction : IAction
	{
		public void Execute()
		{
			var soursePoint = CreatePointAction.GetPoint();

			Console.Write("Enter box name: ");
			var boxName = Console.ReadLine();

			var targetBox = Floor.floor.FindBox(boxName);
			var sourceId = Floor.floor.GetItemId(soursePoint);
			Floor.floor.Move(targetBox.Id, sourceId.Value);
		}
	}
}
