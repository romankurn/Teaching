using System;
using System.Diagnostics;

namespace AlgorithmTester
{
	public abstract class AlgorithmBase
	{
		protected bool _isBestCase;
		protected int[] _array;

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

		protected virtual void PrepareData(int size, int min, int max)
		{
			_array = new int[size];

			if (_isBestCase)
			{
				for (int i = 0; i < size; i++)
				{
					_array[i] = i;
				}
				return;
			}

			var random = new Random();

			for (int i = 0; i < size; i++)
			{
				_array[i] = random.Next(min, max);
			}
		}

		protected abstract void PerformAlgorithm();
	}

}
