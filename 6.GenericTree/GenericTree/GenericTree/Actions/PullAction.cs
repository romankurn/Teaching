using System;
using DynamicMenu;
using OOP1;

namespace GenericTree.Actions
{
	public class PullAction : IAction
	{
		public IOutputParams Execute(IInputParams inputParams = null)
		{
			var point = CreateItemAction.GetPoint();
			point = Floor.floor.FindItem(point);

			Console.WriteLine($"{(point != null ? point.ToString() : "nothing")} was found");

			return null;
		}
	}
}
