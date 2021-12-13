using DynamicMenu;

namespace Polymorphism
{
	internal class Exit : IAction
	{
		public static bool exit = false;

		public void Execute()
		{
			exit = true;
		}
	}
}
