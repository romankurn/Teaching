using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
	public class InsertSort : SortBase
	{
		// from O(n) to O(n2)
		public override void Sort(int[] array)
		{
			for(var i = 1; i < array.Length; i++)
			{
				var current = array[i];
				var j = i;

				while(j > 0 && array[j-1] > current)
				{
					array[j] = array[j-1];
					j--;
				}

				array[j] = current;
			}
		}
	}
}
