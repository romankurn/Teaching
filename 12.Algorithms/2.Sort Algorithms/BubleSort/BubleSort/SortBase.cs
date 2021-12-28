using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
	public abstract class SortBase
	{
		public abstract void Sort(int[] array);

		protected void Swap(int[] array, int i, int j)
		{
			var temp = array[i];
			array[i] = array[j];
			array[j] = temp;
		}
	}
}
