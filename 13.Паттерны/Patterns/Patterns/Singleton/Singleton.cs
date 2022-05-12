using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Singleton
{
	public class Singleton
	{
		private static Singleton _instance;
		private static object syncObject = new object();

		public string Name { get; private set; }

		private Singleton(string name)
		{
			Name = name;
		}

		public static Singleton GetInstance(string name)
		{
			if (_instance == null)
			{
				lock (syncObject)
				{
					if (_instance == null)
						_instance = new Singleton(name);
				}
			}
			
			return _instance;
		}
	}
}
