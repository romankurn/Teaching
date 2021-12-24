using DataStructures;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DataStructureTest
{
	public class QueueTest
	{
		[Test]
		public void EnqueueTest()
		{
			var queue = new CustomQueue<int>();

			queue.Count.Should().Be(0);
			queue.Enqueue(1);
			queue.Count.Should().Be(1);
			queue.Enqueue(2);
			queue.Count.Should().Be(2);
			queue.Enqueue(3);
			queue.Count.Should().Be(3);

			var expectedItem = 1;
			foreach (var item in queue)
			{
				item.Should().Be(expectedItem++);
			}
		}

		[Test]
		public void DequeueTest()
		{
			var queue = new CustomQueue<int>();

			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);

			queue.Dequeue().Should().Be(1);
			queue.Count.Should().Be(2);
			queue.Dequeue().Should().Be(2);
			queue.Count.Should().Be(1);
			queue.Dequeue().Should().Be(3);
			queue.Count.Should().Be(0);
		}

		[Test]
		public void DequeueIfEmptyTest()
		{
			var queue = new CustomQueue<int>();

			Action dequeue = () => queue.Dequeue();

			dequeue.Should().Throw<InvalidOperationException>().WithMessage("Queue is empty");
		}

		[Test]
		public void PeekTest()
		{
			var queue = new CustomQueue<int>();

			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);

			queue.Peek().Should().Be(1);
		}

		[Test]
		public void PeekIfEmptyTest()
		{
			var queue = new CustomQueue<int>();

			Action peek = () => queue.Peek();

			peek.Should().Throw<InvalidOperationException>().WithMessage("Queue is empty");
		}

		[Test]
		public void FirstTest()
		{
			var queue = new CustomQueue<int>();

			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);

			queue.First.Should().Be(1);
		}

		[Test]
		public void FirstIfEmptyTest()
		{
			var queue = new CustomQueue<int>();

			Func<int> first = () => queue.First;

			first.Should().Throw<InvalidOperationException>().WithMessage("Queue is empty");
		}

		[Test]
		public void LastTest()
		{
			var queue = new CustomQueue<int>();

			queue.Enqueue(1);
			queue.Enqueue(2);
			queue.Enqueue(3);

			queue.Last.Should().Be(3);
		}

		[Test]
		public void LastIfEmptyTest()
		{
			var queue = new CustomQueue<int>();

			Func<int> last = () => queue.Last;

			last.Should().Throw<InvalidOperationException>().WithMessage("Queue is empty");
		}
	}
}
