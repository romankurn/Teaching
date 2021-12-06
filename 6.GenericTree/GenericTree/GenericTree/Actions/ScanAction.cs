using DynamicMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTree.Actions
{
	public class ScanAction : IAction
	{
		public void Execute()
		{
			Floor.floor.Scan();
		}
	}
}
