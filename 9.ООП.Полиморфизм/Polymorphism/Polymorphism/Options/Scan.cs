using DynamicMenu;

namespace Polymorphism
{
	public class Scan : IAction
	{
		public void Execute()
		{
			foreach (var pers in University.Persons)
			{
				pers.Print();
			}
		}
	}
}
