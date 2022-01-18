using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTester
{
	public class MaxValuePreparerForSorter : IMaxValuePreparer
	{
		public int FixMaxValue(int size)
		{
			return size / 2;
		}
	}
}
