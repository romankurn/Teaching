using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
	public class Bird : Animal
	{
		public void Move()
		{
			Console.WriteLine("Bird flies");
		}

		public override void Say()
		{
			Console.WriteLine("Bird chiriks");
		}
	}
}
