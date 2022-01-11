using AlgorithmTester;
using System;

namespace SortAlgorithms
{
	public class ShakerSortAdapter : AlgorithmBase
	{
		private ShakerSort _sort = new ShakerSort();

		public ShakerSortAdapter(string name, bool isBestCase) : base(name, isBestCase)
		{
		}

		protected override void PerformAlgorithm()
		{
			_sort.Sort(_array);
		}
	}
}
