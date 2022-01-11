using AlgorithmTester;

namespace SortAlgorithms
{
	public class BubbleSortAdapter : AlgorithmBase
	{
		private BubbleSort _sort = new BubbleSort();

		public BubbleSortAdapter(string name, bool isBestCase) : base(name, isBestCase)
		{
		}

		protected override void PerformAlgorithm()
		{
			_sort.Sort(_array);
		}
	}
}
