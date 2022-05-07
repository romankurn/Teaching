using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer
{
	internal class Implementation
	{
		public static void Imp()
		{
			var timer = new Timer();
			var traficLight = new TraficLight(timer);

			timer.Start();

			Console.ReadKey();

			timer.Stop();

			Console.ReadKey();
			Console.WriteLine("End");
		}		
	}
}
