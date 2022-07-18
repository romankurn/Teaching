using Patterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns
{
	public class Horse : IMovable, INotifier
	{
		public string Name { get; set; }
		
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

		public Horse(int maxSpeed, int stamina, int remainingStrength, int strengthConsumption, string breed, string name = null)
		{
			MaxSpeed = maxSpeed;
			Stamina = stamina;
			RemainingStrength = remainingStrength;
			StrengthConsumption = strengthConsumption;
			Breed = breed;
			Name = name;
		}

		public event EventHandler OnStateChanged;

		public void Shit(int distance)
		{
			Console.WriteLine("обосралась");
			OnStateChanged?.Invoke(this, new EventArgs());
		}

		public double Move(int distance)
		{
			double time = 0;

			for (int i = 0; i < distance; i++)
			{
				Thread.Sleep(100);

				if (RemainingStrength < StrengthConsumption)
				{
					time += Feed();
					Shit(distance);
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
