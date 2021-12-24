using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void BubleSortTest()
		{
			var array = new int[100];
			var expectedArray = new int[100];

			var random = new Random();
			
			for(var i = 0; i < array.Length; i++)
			{
				var value = random.Next(-10000, 10000);
				array[i] = value;
				expectedArray[i] = value;
			}

			var sort = new SortAlgorithms.BubleSort();
			sort.Sort(array);

			expectedArray = expectedArray.OrderBy(a => a).ToArray();

			for(var i = 0; i < array.Length; i++)
			{
				array[i].Should().Be(expectedArray[i]);
			}
		}
	}
}