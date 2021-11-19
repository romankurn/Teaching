using DynamicMenu;

namespace GenericTree
{ 
	public class ExitAction : IAction
	{
		public IOutputParams Execute(IInputParams inputParams = null)
		{
			return new ExitParam {Exit = true};
		}
	}
}
