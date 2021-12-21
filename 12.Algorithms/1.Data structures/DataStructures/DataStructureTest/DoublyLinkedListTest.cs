using DataStructures;
using FluentAssertions;
using NUnit.Framework;

namespace DataStructureTest
{
	public class DoublyLinkedListTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void AddLastTest()
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.Count.Should().Be(0);

			linkedList.AddLast(1);
			linkedList.Count.Should().Be(1);

			linkedList.AddLast(2);
			linkedList.Count.Should().Be(2);

			linkedList.AddLast(3);
			linkedList.Count.Should().Be(3);

			var expectedItem = 1;
			foreach (var item in linkedList)
			{
				item.Should().Be(expectedItem++);
				linkedList.Count.Should().Be(3);
			}
		}

		[Test]
		public void AddFirstTest()
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.Count.Should().Be(0);

			linkedList.AddFirst(3);
			linkedList.Count.Should().Be(1);

			linkedList.AddFirst(2);
			linkedList.Count.Should().Be(2);

			linkedList.AddFirst(1);
			linkedList.Count.Should().Be(3);

			var expectedItem = 1;
			foreach (var item in linkedList)
			{
				item.Should().Be(expectedItem++);
				linkedList.Count.Should().Be(3);
			}
		}

		[Test]
		public void AddFirstAndAddLastTest() // есть ли смысл в таком? 
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.Count.Should().Be(0);

			linkedList.AddLast(3);
			linkedList.Count.Should().Be(1);
			linkedList.AddFirst(2);
			linkedList.Count.Should().Be(2);
			linkedList.AddLast(4);
			linkedList.Count.Should().Be(3);
			linkedList.AddFirst(1);
			linkedList.Count.Should().Be(4);

			var expectedItem = 1;
			foreach (var item in linkedList)
			{
				item.Should().Be(expectedItem++);
				linkedList.Count.Should().Be(4);
			}
		}

		[Test]
		public void ContainsSuccessesTest()
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.AddLast(2);
			linkedList.AddLast(3);
			linkedList.AddFirst(1);

			linkedList.Contains(1).Should().BeTrue();
			linkedList.Contains(2).Should().BeTrue();
			linkedList.Contains(3).Should().BeTrue();
		}

		[Test]
		public void ContainsIfDoesNotExestTest()
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			linkedList.Contains(0).Should().BeFalse();
		}

		[Test]
		[Order(1)]
		public void AnyWithoutFilterSuccessesTest()
		{
			var linkedList = new DoublyLinkedList<string>();

			linkedList.AddLast("a");
			linkedList.AddLast("b");
			linkedList.AddLast("c");

			linkedList.Any().Should().BeTrue();
		}

		[Test]
		[Order(1)]
		public void AnyWithoutFilterFailedTest()
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.Any().Should().BeFalse();
		}

		[Test]
		[Order(1)]
		public void AnyWithFilterSuccessesTest()
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			linkedList.Any(t => t > 1).Should().BeTrue();
			linkedList.Any(t => t % 2 == 0).Should().BeTrue();
			linkedList.Any(t => t < 10 && t % 3 == 0).Should().BeTrue();
		}

		[Test]
		[Order(1)]
		public void AnyWithFilterFailedTest()
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			linkedList.Any(t => t < 0).Should().BeFalse();
		}

		[Test]
		[Order(2)]
		public void RemoveIfOneElementSuccessesTest()
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.AddLast(1);

			linkedList.Remove(1).Should().BeTrue();
			linkedList.Count.Should().Be(0);
			linkedList.Any().Should().BeFalse();

			linkedList.AddFirst(1);
			linkedList.Remove(1).Should().BeTrue();
			linkedList.Count.Should().Be(0);
			linkedList.Any().Should().BeFalse();
		}

		[Test]
		public void RemoveIfHeadSuccessesTest()
		{
			var linkedList1 = new DoublyLinkedList<int>();

			linkedList1.AddLast(1);
			linkedList1.AddLast(2);

			linkedList1.Remove(1).Should().BeTrue();
			linkedList1.Count.Should().Be(1);

			foreach (var item in linkedList1)
			{
				item.Should().Be(2);
			}

			var linkedList2 = new DoublyLinkedList<int>();

			linkedList2.AddFirst(2);
			linkedList2.AddFirst(1);

			linkedList2.Remove(1).Should().BeTrue();
			linkedList2.Count.Should().Be(1);

			foreach (var item in linkedList2)
			{
				item.Should().Be(2);
			}
		}

		[Test]
		public void RemoveIfExistsSuccessesTest()
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.AddFirst(4);
			linkedList.AddFirst(3);
			linkedList.AddFirst(3);
			linkedList.AddFirst(2);
			linkedList.AddFirst(1);

			linkedList.Remove(3).Should().BeTrue();
			linkedList.Count.Should().Be(4);

			var expectedItem = 1;
			foreach (var item in linkedList)
			{
				item.Should().Be(expectedItem++);
				linkedList.Count.Should().Be(4);
			}
		}

		[Test]
		public void RemoveIfTailSuccessesTest()
		{
			var linkedList1 = new DoublyLinkedList<int>();

			linkedList1.AddLast(1);
			linkedList1.AddLast(2);
			linkedList1.AddLast(3);

			linkedList1.Remove(3).Should().BeTrue();
			linkedList1.Count.Should().Be(2);

			var expectedItem = 1;
			foreach (var item in linkedList1)
			{
				item.Should().Be(expectedItem++);
				linkedList1.Count.Should().Be(2);
			}

			expectedItem = 1;
			linkedList1.AddLast(3);
			foreach (var item in linkedList1)
			{
				item.Should().Be(expectedItem++);
				linkedList1.Count.Should().Be(3);
			}

			var linkedList2 = new DoublyLinkedList<int>();

			linkedList2.AddFirst(3);
			linkedList2.AddFirst(2);
			linkedList2.AddFirst(1);

			linkedList2.Remove(3).Should().BeTrue();
			linkedList2.Count.Should().Be(2);

			expectedItem = 1;
			foreach (var item in linkedList2)
			{
				item.Should().Be(expectedItem++);
				linkedList2.Count.Should().Be(2);
			}

			expectedItem = 1;
			linkedList2.AddLast(3);
			foreach (var item in linkedList2)
			{
				item.Should().Be(expectedItem++);
				linkedList2.Count.Should().Be(3);
			}
		}

		[Test]
		public void RemoveIfDoesNotExestTest()
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			linkedList.Remove(4).Should().BeFalse();
			linkedList.Count.Should().Be(3);

			var expectedItem = 1;
			foreach (var item in linkedList)
			{
				item.Should().Be(expectedItem++);
				linkedList.Count.Should().Be(3);
			}
		}

		[Test]
		public void BackEnumeratorTest()
		{
			var linkedList = new DoublyLinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			var expected = 3;

			foreach(var item in linkedList.GetBackEnumerator())
			{
				item.Should().Be(expected--);
			}
		}
	}
}
