using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
	public class Auto : ITransport
	{
		public void Drive()
		{
			Console.WriteLine("Auto drives");
		}
	}
}
