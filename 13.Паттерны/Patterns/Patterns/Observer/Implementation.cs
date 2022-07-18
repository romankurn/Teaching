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

		public static void ImpHorse()
		{
			var horse1 = new Horse(10, 10, 10, 5, "breed1", "звёздочка");

			var horse2 = new Horse(10, 50, 10, 10, "breed1", "молния");

			var car = new Car();

			var veh1 = new Vehicle(horse1, 1);
			var veh2 = new Vehicle(horse2, 1);
			var veh3 = new Vehicle(car, 1);

			veh1.Move(50);
			veh2.Move(50);
			veh3.Move(50);

			Console.ReadKey();
		}
	}
}
