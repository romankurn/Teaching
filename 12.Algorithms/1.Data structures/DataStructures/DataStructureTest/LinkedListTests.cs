using DataStructures.LinkedList;
using FluentAssertions;
using NUnit.Framework;

namespace DataStructureTest
{
	public class LinkedListTests

	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void AddLastTest()
		{
			var linkedList = new LinkedList<int>();

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
			var linkedList = new LinkedList<int>();

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
		public void ContainsIfTrueTest()
		{
			var linkedList = new LinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			linkedList.Contains(1).Should().BeTrue();
			linkedList.Contains(2).Should().BeTrue();
			linkedList.Contains(3).Should().BeTrue();
		}

		[Test]
		public void ContainsIfFalseTest()
		{
			var linkedList = new LinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			linkedList.Contains(4).Should().BeFalse();
		}

		[Test]
		[Order(1)]
		public void AnyWithoutFilterIfFalseTest()
		{
			var linkedList = new LinkedList<int>();

			linkedList.Any().Should().BeFalse();
		}

		[Test]
		[Order(2)]
		public void AnyWithoutFilterIfTrueTest()
		{
			var linkedList = new LinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			linkedList.Any().Should().BeTrue();
		}

		[Test]
		[Order(3)]
		public void AnyWithFilterIfTrueTest()
		{
			var linkedList = new LinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			linkedList.Any(t => t > 1).Should().BeTrue();
			linkedList.Any(t => t % 2 == 0).Should().BeTrue();
			linkedList.Any(t => t < 10 && t % 3 == 0).Should().BeTrue();
		}

		[Test]
		[Order(4)]
		public void AnyWithFilterIfFalseTest()
		{
			var linkedList = new LinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			linkedList.Any(t => t < 0).Should().BeFalse();
		}

		[Test]
		[Order(5)]
		public void RemoveIfOneElementSuccessesTest()
		{
			var linkedList = new LinkedList<int>();

			linkedList.AddLast(1);

			linkedList.Remove(1).Should().BeTrue();
			linkedList.Count.Should().Be(0);
			linkedList.Any().Should().BeFalse();
		}

		[Test]
		[Order(5)]
		public void RemoveIfHeadSuccessesTest()
		{
			var linkedList = new LinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);

			linkedList.Remove(1).Should().BeTrue();
			linkedList.Count.Should().Be(1);
			linkedList.Any().Should().BeTrue();

			foreach(var item in linkedList)
			{
				item.Should().Be(2);
			}
		}

		[Test]
		[Order(5)]
		public void RemoveIfExestsSuccessesTest()
		{
			var linkedList = new LinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(3);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			linkedList.Remove(3).Should().BeTrue();
			linkedList.Count.Should().Be(3);

			var expectedItem = 1;
			foreach (var item in linkedList)
			{
				item.Should().Be(expectedItem++);
				linkedList.Count.Should().Be(3);
			}
		}

		[Test]
		[Order(5)]
		public void RemoveIfTailSuccessesTest()
		{
			var linkedList = new LinkedList<int>();

			linkedList.AddLast(1);
			linkedList.AddLast(2);
			linkedList.AddLast(3);

			linkedList.Remove(3).Should().BeTrue();
			linkedList.Count.Should().Be(2);

			var expectedItem = 1;
			foreach (var item in linkedList)
			{
				item.Should().Be(expectedItem++);
				linkedList.Count.Should().Be(2);
			}

			expectedItem = 1;
			linkedList.AddLast(3);
			foreach (var item in linkedList)
			{
				item.Should().Be(expectedItem++);
				linkedList.Count.Should().Be(3);
			}
		}

		[Test]
		[Order(5)]
		public void RemoveIfDoesNotExestTest()
		{
			var linkedList = new LinkedList<int>();

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
	}
}