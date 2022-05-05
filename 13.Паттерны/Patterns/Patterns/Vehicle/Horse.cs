using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
	public class Horse : IMovable
	{
		public int MaxSpeed { get; private set; }

		public int Stamina { get; private set; }

		public int RemainingStrength { get; private set; }

		public int StrengthConsumption { get; private set; }

		public string Breed { get; private set; }

		public Horse()
		{
			MaxSpeed = 10;
			Stamina = 30;
			RemainingStrength = Stamina;
			StrengthConsumption = 2;
			Breed = "BreedXXX";
		}

		public Horse(int maxSpeed, int stamina, int remainingStrength, int strengthConsumption, string breed)
		{
			MaxSpeed = maxSpeed;
			Stamina = stamina;
			RemainingStrength = remainingStrength;
			StrengthConsumption = strengthConsumption;
			Breed = breed;
		}
		
		public double Move(int distance)
		{
			double time = 0;

			for (int i = 0; i < distance; i++)
			{
				if (RemainingStrength < StrengthConsumption)
				{
					time += Feed();
				}

				RemainingStrength -= StrengthConsumption;
			}

			time += (double)distance / MaxSpeed;

			return time;
		}

		private int Feed()
		{
			RemainingStrength += Stamina;
			return 60;
		}
	}
}
