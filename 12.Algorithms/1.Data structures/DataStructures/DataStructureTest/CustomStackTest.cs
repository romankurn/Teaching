using DataStructures;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DataStructureTest
{
	public class CustomStackTest
	{
		[Test]
		public void PushTest()
		{
			var stack = new CustomStack<int>();

			stack.Count.Should().Be(0);
			stack.Push(1);
			stack.Count.Should().Be(1);
			stack.Push(2);
			stack.Count.Should().Be(2);

			var expectedItem = 2;
			foreach (var item in stack)
			{
				item.Should().Be(expectedItem--);
			}
		}

		[Test]
		public void PeekTest()
		{
			var stack = new CustomStack<int>();

			stack.Push(1);
			stack.Push(2);
			stack.Push(3);

			stack.Peek().Should().Be(3);
			stack.Count.Should().Be(3);

			var expectedItem = 3;
			foreach (var item in stack)
			{
				item.Should().Be(expectedItem--);
			}
		}

		[Test]
		public void PeekIfEmptyTest()
		{
			var stack = new CustomStack<int>();

			Action peek = () => stack.Peek();

			peek.Should().Throw<InvalidOperationException>().WithMessage("Stack is empty");
		}

		[Test]
		public void PopTest()
		{
			var stack = new CustomStack<int>();

			stack.Push(1);
			stack.Push(2);
			stack.Push(3);

			stack.Pop().Should().Be(3);
			stack.Count.Should().Be(2);
			stack.Pop().Should().Be(2);
			stack.Count.Should().Be(1);
			stack.Pop().Should().Be(1);
			stack.Count.Should().Be(0);
		}

		[Test]
		public void PopIfEmptyTest()
		{
			var stack = new CustomStack<int>();

			Action pop = () => stack.Pop();

			pop.Should().Throw<InvalidOperationException>().WithMessage("Stack is empty");
		}
	}
}
