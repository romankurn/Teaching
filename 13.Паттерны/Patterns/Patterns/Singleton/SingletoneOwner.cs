using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Singleton
{
	public class SingletoneOwner
	{
		public Singleton Singleton { get; private set; }

		public void CreateSingleton(string name)
		{
			Singleton = Singleton.GetInstance(name);
		}
	}
}
