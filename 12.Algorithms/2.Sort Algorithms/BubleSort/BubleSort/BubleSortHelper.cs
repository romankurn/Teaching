using AlgorithmTester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
	public class BubleSortHelper : AlgorithmBase
	{
		private int[] _array;
		private BubleSort _sort = new BubleSort();

		protected override void PerformAlgorithm()
		{
			_sort.Sort(_array);
		}

		protected override void PrepareData(int size, int min, int max)
		{
			_array = new int[size];

			var random = new Random();

			for(int i = 0; i < size; i++)
			{
				_array[i] = random.Next(min, max);
			}
		}
	}
}
