using System.Diagnostics;

namespace AlgorithmTester
{
	public abstract class AlgorithmBase
	{
		public double DoTest(int size, int min, int max)
		{
			PrepareData(size,min, max);
			
			var stopwatch = new Stopwatch();

			stopwatch.Start();
			PerformAlgorithm();
			stopwatch.Stop();

			return stopwatch.ElapsedMilliseconds;
		}

		protected abstract void PrepareData(int size, int min, int max);

		protected abstract void PerformAlgorithm();
	}

}
