using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
	public class RunningHorse : Horse
	{
		public RunningHorse() : base("RunningHorse")
		{

		}

		public override int GetSpeed()
		{
			return 25;
		}

		public override void Move()
		{
			Console.Write($"{Name} moves");
		}
	}
}
