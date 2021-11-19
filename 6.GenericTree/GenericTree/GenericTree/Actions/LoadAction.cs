using DynamicMenu;
using ObjectSaver;
using OOP1;

namespace GenericTree
{
	public class LoadAction : IAction
	{
		private string _fileName;

		public LoadAction(string fileName)
		{
			_fileName = fileName;
		}

		public IOutputParams Execute(IInputParams inputParams = null)
		{
			Floor.floor = File<Inventory<Point>>.GetItemFromFile(_fileName);
			return null;
		}
	}
}
