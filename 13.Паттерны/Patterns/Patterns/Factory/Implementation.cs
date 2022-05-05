using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Factory
{
	public class Implementation
	{
		public static void Move()
		{
			var factory = new Factory();

			var horseTime = factory.GetVehicle(Vehicles.Horse).Move(1000);
			var carTime = factory.GetVehicle(Vehicles.Car).Move(1000);
			var scooterTime = factory.GetVehicle(Vehicles.Scooter).Move(1000);

			Console.WriteLine($"horseTime: {horseTime}, carTime: {carTime}, scooterTime: {scooterTime}");
		}
	}
}
