using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
	internal class Animal : ICat, IDog
	{
		public void Say()
		{
			Console.WriteLine("Animal says");
		}

	}
}
