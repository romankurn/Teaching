using System;

namespace Patterns.Observer
{
	public interface INotifier
	{
		event EventHandler OnStateChanged;
	}
}
