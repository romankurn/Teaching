namespace DynamicMenu
{
	public interface IAction
	{
		IOutputParams Execute(IInputParams inputParams = null);
	}
}
