using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
	public class FibonacciTester
	{
		public async Task<List<Result>> DoTest(int numberOfSearchedMember)
		{
			var finder = new FibonacciSequenceMemberFinder();

			var recurtionTestTask = MeasureSearchTime(numberOfSearchedMember,new FibonachaRecursive());

			var cycleTestTask = MeasureSearchTime(numberOfSearchedMember, new FibonachaIterative());

			await Task.WhenAll(recurtionTestTask, cycleTestTask);

			var recurtionResult = recurtionTestTask.Result;
			var cycleResult = cycleTestTask.Result;

			return new List<Result> { recurtionResult, cycleResult };
		}

		private Task<Result> MeasureSearchTime(int numberOfSearchedMember, IFibonacha fiba)
		{
			Stopwatch stopWatch = new Stopwatch();			

			stopWatch.Start();
			var ReceivedValue = fiba.GetFibonacciMember(numberOfSearchedMember);
			stopWatch.Stop();

			var result = new Result(stopWatch.ElapsedTicks, ReceivedValue);

			return Task.FromResult(result);
		}

	}
}
