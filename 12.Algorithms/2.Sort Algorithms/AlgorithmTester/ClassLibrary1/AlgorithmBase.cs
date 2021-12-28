using System.Diagnostics;

namespace AlgorithmTester
{
	public abstract class AlgorithmBase
	{
		protected bool _isBestCase;
		public string Name { get; protected set; }

		protected AlgorithmBase(string name, bool isBestCase)
		{
			Name = name;
			_isBestCase = isBestCase;
		}

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
