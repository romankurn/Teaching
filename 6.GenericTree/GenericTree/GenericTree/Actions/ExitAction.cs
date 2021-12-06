using DynamicMenu;

namespace GenericTree.Actions
{
	public class ExitAction : IAction
	{
		public static bool exit = false;
		public void Execute()
		{
			exit = true;
		}
	}
}
