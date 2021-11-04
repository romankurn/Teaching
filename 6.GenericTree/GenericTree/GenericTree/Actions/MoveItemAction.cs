using System;
using DynamicMenu;
using OOP1;

namespace GenericTree
{
	public class MoveItemAction : IAction
	{
		public IOutputParams Execute(IInputParams inputParams = null)
		{
			var soursePoint = CreateItemAction.GetPoint();

			Console.Write("Enter box name: ");
			var boxName = Console.ReadLine();

			var targetBox = Floor.floor.FindBox(boxName);
			var sourceId = Floor.floor.GetItemId(soursePoint);
			Floor.floor.Move(targetBox.Id, sourceId.Value);

			return null;
		}
	}
}
