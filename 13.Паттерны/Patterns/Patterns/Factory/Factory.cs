using System;

namespace Patterns.Factory
{
	public class Factory
	{
		private Car _car = new Car();
		private Horse _horse = new Horse();
		private Scooter _scooter = new Scooter();

		public IMovable GetVehicle(Vehicles vehicle)
		{
			switch (vehicle)
			{
				case (Vehicles.Scooter):
					return _scooter;

				case (Vehicles.Car):
					return _car;

				case (Vehicles.Horse):
					return _horse;

				default:
					throw new ArgumentException();
			}

		}
	}
}
