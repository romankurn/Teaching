using AlgorithmTester;

namespace SortAlgorithms
{
	public class InsertSortAdapter : AlgorithmBase
	{
		private InsertSort _sort = new InsertSort();

		public InsertSortAdapter(string name, bool isBestCase) : base(name, isBestCase)
		{
		}

		protected override void PerformAlgorithm()
		{
			_sort.Sort(_array);
		}
	}
}
