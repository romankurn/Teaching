using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
	public class Pegasus : HorseDecorator
	{
		public Pegasus(Horse horse, string name) : base(horse, $"{name} - Pegasus")
		{
		}

		public override int GetSpeed()
		{
			return _horse.GetSpeed() + 15;
		}

		public override void Move()
		{
			_horse.Move();
			Console.Write($" like Pegasus");
		}
	}
}
