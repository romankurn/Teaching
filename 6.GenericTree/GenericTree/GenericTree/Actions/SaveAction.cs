using DynamicMenu;
using ObjectSaver;
using OOP1;

namespace GenericTree.Actions
{
	public class SaveAction : IAction
	{
		private string _fileName;

		public SaveAction(string fileName)
		{
			_fileName = fileName;
		}

		public void Execute()
		{
			File<Inventory<Point>>.Save(_fileName, Floor.floor);
		}
	}
}
