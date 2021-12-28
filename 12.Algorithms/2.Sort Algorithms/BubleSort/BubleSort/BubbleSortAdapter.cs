using AlgorithmTester;
using System;

namespace SortAlgorithms
{
	public class BubbleSortAdapter : AlgorithmBase
	{
		private int[] _array;
		private BubbleSort _sort = new BubbleSort();

		public BubbleSortAdapter(string name, bool isBestCase) : base(name, isBestCase)
		{
		}

		protected override void PerformAlgorithm()
		{
			_sort.Sort(_array);
		}

		protected override void PrepareData(int size, int min, int max)
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
	}
}
