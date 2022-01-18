using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
	public class Sorter2
	{
		public int[] Sort(int[] array)
		{
			var repetitionDictionary = new Dictionary<int, int>();
			foreach (var item in array)
			{
				if (repetitionDictionary.ContainsKey(item))
					repetitionDictionary[item]++;
				else
					repetitionDictionary.Add(item, 1);
			}

			repetitionDictionary = repetitionDictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(keyValue => keyValue.Key, keyValue => keyValue.Value);

			var sortedArray = new List<int>();

			foreach(var repetitionPair in repetitionDictionary)
			{
				sortedArray.AddRange(Enumerable.Repeat(repetitionPair.Key, repetitionPair.Value));
			}

			return sortedArray.ToArray();
		}
	}
}
