using DynamicMenu;
using OOP1;

namespace GenericTree
{
	public class ScanAction: IAction
	{
		public IOutputParams Execute(IInputParams inputParams = null)
		{
			Floor.floor.Scan();
			return null;
		}
	}
}
