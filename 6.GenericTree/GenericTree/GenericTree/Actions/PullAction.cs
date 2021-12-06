using DynamicMenu;
using System;

namespace GenericTree.Actions
{
	public class PullAction : IAction
	{
		public void Execute()
		{
			var point = CreatePointAction.GetPoint();
			point = Floor.floor.FindItem(point);

			Console.WriteLine($"{(point != null ? point : "nothing")} was found");
		}
	}
}
