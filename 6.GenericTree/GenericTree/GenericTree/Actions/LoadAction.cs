using DynamicMenu;
using ObjectSaver;
using OOP1;

namespace GenericTree.Actions
{
	public class LoadAction : IAction
	{
		private string _fileName;

		public LoadAction(string fileName)
		{
			_fileName = fileName;
		}

		public void Execute()
		{
			File<Inventory<Point>>.GetItemFromFile(_fileName);
		}
	}
}
