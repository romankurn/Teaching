using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
	public class Camel : IAnimal
	{
		public void Move()
		{
			Console.WriteLine("Camel goes");
		}

		public void Say()
		{
			Console.WriteLine("Camal says");
		}
	}
}
