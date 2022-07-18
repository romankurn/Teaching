using FluentAssertions;
using NUnit.Framework;
using SortAlgorithms;
using SortAlgorithms.EffictiveSorts;
using System;
using System.Linq;

namespace Tests
{
	public class SortTests
	{
		public void SortArray(SortBase algorithm)
		{
			var array = new int[100];
			var expectedArray = new int[100];

			var random = new Random();

			for (var i = 0; i < array.Length; i++)
			{
				var value = random.Next(-10000, 10000);
				array[i] = value;
				expectedArray[i] = value;
			}

			algorithm.Sort(array);

			expectedArray = expectedArray.OrderBy(a => a).ToArray();

			for (var i = 0; i < array.Length; i++)
			{
				array[i].Should().Be(expectedArray[i]);
			}
		}

		[Test]
		public void BubbleSortTest()
		{
			var sort = new BubbleSort();

			SortArray(sort);
		}

		[Test]
		public void ShakerSortTest()
		{
			var sort = new ShakerSort();

			SortArray(sort);
		}

		[Test]
		public void InsertSortTest()
		{
			var sort = new InsertSort();

			SortArray(sort);
		}

		[Test]
		public void QuickSort()
		{
			var sort = new QuickSort();

			SortArray(sort);
		}
	}
}