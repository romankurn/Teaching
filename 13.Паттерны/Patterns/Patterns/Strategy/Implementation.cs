using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Strategy
{
	public class Implementation
	{
		public static void Move()
		{
			var horse = new Vehicle(new Horse(15, 50, 50, 1, "Horse"), 1);

			var car = new Vehicle(new Car(100, 75, 75, 1, "Car"), 4);

			var scooter = new Vehicle(new Scooter(25, 100, 100, 8, "scooter"), 2);

			var horseTime = horse.Move(1000);
			var carTime = car.Move(1000);
			var scooterTime = scooter.Move(1000);

			Console.WriteLine($"horseTime: {horseTime}, carTime: {carTime}, scooterTime: {scooterTime}");
		}
	}
}
