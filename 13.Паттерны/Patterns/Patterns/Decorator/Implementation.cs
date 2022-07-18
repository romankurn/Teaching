using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
	public class Implementation
	{
		public static void Execute()
		{
			var runningHorse = new RunningHorse();
			var workingHorse = new WorkingHorse();

			//runningHorse.Move();

			//Console.WriteLine();

			//workingHorse.Move();

			var runningPegasus = new Pegasus(runningHorse, "RunningHorse");
			var workingPegasus = new Pegasus(workingHorse, "WorkingHorse");

			//runningPegasus.Move();
			//Console.WriteLine();
			//workingPegasus.Move();

			var runningPegasusUnicorn = new Unicorn(runningPegasus, "RunningHorse");
			var workingPegasusUnicorn = new Unicorn(workingPegasus, "WorkingHorse");

			runningPegasusUnicorn.Move();
			Console.WriteLine();
			workingPegasusUnicorn.Move();
		}
	}
}
