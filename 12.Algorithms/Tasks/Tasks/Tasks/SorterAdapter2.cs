using AlgorithmTester;
using System;
using System.Linq;

namespace Tasks
{
	public class SorterAdapter2 : AlgorithmBase
	{
		private Sorter2 _sort = new Sorter2();

		public SorterAdapter2(string name, bool isBestCase) : base(name, isBestCase)
		{
		}

		protected override void PerformAlgorithm()
		{
			_sort.Sort(_array);
		}

		protected override void PrepareData(int size, int min, int max)
		{
			var random = new Random();
			_array = new int[size];

			if (_isBestCase)
			{
				_array = Enumerable.Repeat(random.Next(min, max), size).ToArray();
				return;
			}

			for (int i = 0; i < size; i++)
			{
				_array[i] = random.Next(min, max);
			}
		}
	}
}
