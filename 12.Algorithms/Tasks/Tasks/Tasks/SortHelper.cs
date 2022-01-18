using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
	public class SortHelper
	{
		public List<ExtendedData> _modifiedDate;

		public SortHelper()
		{
			_modifiedDate = new List<ExtendedData>();
		}

		public void CountRepetitions(int[] array)
		{
			if (array == null)
				throw new ArgumentNullException("Array is empty");

			_modifiedDate = new List<ExtendedData>();
			//_modifiedDate.Add(new ExtendedData(array[0]));

			//for (var i = 1; i < array.Length; i++)
			//{
			//	for (var j = 0; j < _modifiedDate.Count; j++)
			//	{
			//		if (_modifiedDate[j].Value == array[i])
			//		{
			//			_modifiedDate[j].Repetitions++;
			//			break;
			//		}
			//		if (j == _modifiedDate.Count - 1 && _modifiedDate[j].Value != array[i])
			//		{
			//			_modifiedDate.Add(new ExtendedData(array[i]));
			//			break;
			//		}
			//	}
			//}

			for (var i = 0; i < array.Length; i++)
			{
				var modifiedDate = _modifiedDate.FirstOrDefault(m => m.Value == array[i]);

				if (modifiedDate != null)
					modifiedDate.Repetitions++;
				else
					_modifiedDate.Add(new ExtendedData(array[i]));
			}
		}

		public void SortByRepetitions()
		{
			//for (var i = 1; i < _modifiedDate.Count; i++)
			//{
			//	var current = _modifiedDate[i];
			//	var j = i;

			//	while (j > 0 && _modifiedDate[j - 1].Repetitions < current.Repetitions)
			//	{
			//		_modifiedDate[j] = _modifiedDate[j - 1];
			//		j--;
			//	}

			//	_modifiedDate[j] = current;
			//}

			_modifiedDate = _modifiedDate.OrderByDescending(x => x.Repetitions).ThenBy(x => x.Value).ToList();
		}

		//public void SortByValue()
		//{
		//	for (var i = 1; i < _modifiedDate.Count; i++)
		//	{
		//		var current = _modifiedDate[i];
		//		var j = i;

		//		while (j > 0 && _modifiedDate[j - 1].Repetitions == current.Repetitions && _modifiedDate[j - 1].Value > current.Value)
		//		{
		//			_modifiedDate[j] = _modifiedDate[j - 1];
		//			j--;
		//		}

		//		_modifiedDate[j] = current;
		//	}
		//}

		public int[] GetSortedArray()
		{
			var sortedArray = new List<int>();

			foreach (var item in _modifiedDate)
			{ 
				//{
				//	for (var j = 1; j <= item.Repetitions; j++)
				//	{
				//		sortedArray[i++] = item.Value;
				//	}

				sortedArray.AddRange(Enumerable.Repeat(item.Value, item.Repetitions));
			}

			return sortedArray.ToArray();
		}
	}
}
