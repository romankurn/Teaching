using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
	public class BubleSort
	{
		//O(n^2) - O(n)
		public void Sort(int[] array)
		{
			for (var i = 0; i < array.Length; i++)
			{
				for (int j = 1; j < array.Length - i; j++)
				{
					if (array[j-1] > array[j])
						Swap(array, j-1, j);
				}
			}
		}

		private void Swap(int[] array, int i, int j)
		{
			var temp  = array[i];
			array[i] = array[j];
			array[j] = temp;
		}
	}


}
