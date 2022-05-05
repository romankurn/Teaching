using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
	internal class Scooter : IMovable
	{
		public int MaxSpeed { get ; private set; }
		
		public int Cardge { get ; private set; }

		public int RemainingCardge { get; private set; }

		public int CardgeConsumption { get; private set; }

		public string Model { get ; private set; }

		public Scooter()
		{
			MaxSpeed = 20;			
			Cardge = 100;
			RemainingCardge = Cardge;
			CardgeConsumption = 10;
			Model = "ModelXXX";
		}

		public Scooter(int maxSpeed, int cardge, int remainingCardge, int cardgeConsumption, string model)
		{
			MaxSpeed = maxSpeed;
			Cardge = cardge;
			RemainingCardge = remainingCardge;
			CardgeConsumption = cardgeConsumption;
			Model = model;
		}

		public double Move(int distance)
		{
			double time = 0;

			for (int i = 0; i < distance; i++)
			{
				if (RemainingCardge < CardgeConsumption)
				{
					time += CardgeBattery(Cardge);
				}

				RemainingCardge -= CardgeConsumption;
			}

			time += (double)distance / MaxSpeed;

			return time;
		}

		private int CardgeBattery(int volume)
		{
			RemainingCardge += volume;
			return 40;
		}
	}
}
