using AlgorithmTester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
	public class SorterAdapter : AlgorithmBase
	{
		private Sorter _sort = new Sorter();

		public SorterAdapter(string name, bool isBestCase) : base(name, isBestCase)
		{
		}

		protected override void PerformAlgorithm()
		{
			_sort.GetSordedByCount(_array);
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
