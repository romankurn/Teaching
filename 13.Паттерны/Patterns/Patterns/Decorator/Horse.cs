using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
	public abstract class Horse
	{
		public string Name { get; protected set; }

		protected Horse(string name)
		{
			Name = name;
		}

		public abstract void Move();

		public abstract int GetSpeed();

	}
}
