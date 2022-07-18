using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
	public class WorkingHorse : Horse
	{
		public WorkingHorse() : base("WorkingHorse")
		{

		}

		public override int GetSpeed()
		{
			return 15;
		}

		public override void Move()
		{
			Console.Write($"{Name} moves");
		}
	}
}
