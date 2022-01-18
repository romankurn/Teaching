using FluentAssertions;
using NUnit.Framework;
using Tasks;

namespace Tests
{
	public class SorterTest
	{
		[Test]
		public void GetSordedByCountTest()
		{
			var array = new int[20] { 3, 3, 3, 2, 2, 1, 4, 4, 4, 4, 6, 6, 6, 6, 6, 5, 5, 5, 5, 5 };
			var expectedArray = new int[20] { 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 4, 4, 4, 4, 3, 3, 3, 2, 2, 1 };

			var sorter = new Sorter();
			var sortedArray = sorter.GetSordedByCount(array);

			for (var i = 0; i < array.Length; i++)
			{
				sortedArray[i].Should().Be(expectedArray[i]);
			}
		}

		[Test]
		public void GetSordedByCountTest2()
		{
			var array = new int[20] { 3, 3, 3, 2, 2, 1, 4, 4, 4, 4, 6, 6, 6, 6, 6, 5, 5, 5, 5, 5 };
			var expectedArray = new int[20] { 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 4, 4, 4, 4, 3, 3, 3, 2, 2, 1 };

			var sorter = new Sorter2();
			var sortedArray = sorter.Sort(array);

			for (var i = 0; i < array.Length; i++)
			{
				sortedArray[i].Should().Be(expectedArray[i]);
			}
		}

		//[Test] как тестировать такой случай?
		//public void GetSordedByCountEmptyArrayTest()
		//{
		//	int[] array;

		//	var sorter = new Sorter(array);
		//	var sortedArray = sorter.GetSordedByCount();
		//}


	}
}
