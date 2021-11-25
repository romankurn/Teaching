using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public class Mammal : Animal
	{
		public void Move()
		{
			Console.WriteLine("Mammal moves");
		}

		public override void Say()
		{
			Console.WriteLine("Mammal says");
		}
	}
}
