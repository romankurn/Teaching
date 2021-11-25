using System;

namespace Polymorphism
{
	public abstract class Animal
	{
		public virtual void Move()
		{
			Console.WriteLine("Animal moves");
		}

		public virtual void Say()
		{
			Console.WriteLine("Animal says");
		}
	}
}
