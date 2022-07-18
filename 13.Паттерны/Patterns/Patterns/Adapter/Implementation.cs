using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
	public class Implementation
	{
		public static void Move()
		{
			var driver = new Driver();
			var car = new Auto();
			var camel = new Camel();
			var adapter = new AnimalToTransportAdapter(camel);

			driver.Travel(car);
			driver.Travel(adapter);
		}
	}
}
