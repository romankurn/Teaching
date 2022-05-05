using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns
{
	public class Car : IMovable
	{
		public int MaxSpeed { get ; private set; }

		public int TankVolume { get ; private set; }

		public int RemainingFuel { get ; private set; }

		public int FuelConsumption { get ; private set; }

		public string Model { get ; private set; }

		

		public Car()
		{
			MaxSpeed = 80;			
			TankVolume = 10;
			RemainingFuel = TankVolume;
			FuelConsumption = 1;
			Model = "ModelXXX";
		}

		public Car(int maxSpeed, int tankVolume, int remainingFuel, int fuelConsumption, string model)
		{
			MaxSpeed = maxSpeed;			
			TankVolume = tankVolume;
			RemainingFuel = remainingFuel;
			FuelConsumption = fuelConsumption;
			Model = model;
		}

		public double Move(int distance)
		{
			double time = 0;
			
			for(int i = 0; i < distance; i++)
			{
				if(RemainingFuel < FuelConsumption)
				{
					time += Refuel(TankVolume);
				}

				RemainingFuel -= FuelConsumption;
			}

			time += (double)distance / MaxSpeed;

			return time;
		}

		private int Refuel(int volume)
		{
			RemainingFuel += volume;
			return 10;
		}
	}
}
