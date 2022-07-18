using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
	public class Unicorn : HorseDecorator
	{
		public Unicorn(Horse horse, string name) : base(horse, $"{name} - Unicorn")
		{
		}

		public override int GetSpeed()
		{
			return _horse.GetSpeed() + 5;
		}

		public override void Move()
		{
			_horse.Move();
			Console.Write($" like Unicorn");
		}
	}
}
