using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
	public class CustomStack<T> : IEnumerable<T>
	{
		private class StackItem<Type>
		{
			public StackItem(Type data)
			{
				Data = data;
			}

			public Type Data { get; set; }
			public StackItem<Type> Next { get; set; }
		}

		private StackItem<T> _head;
		public int Count { get; private set; }

		//O(1)
		public void Push(T data)
		{
			var node = new StackItem<T>(data);

			node.Next = _head;
			_head = node;
			Count++;
		}

		//O(1)
		public T Peek()
		{
			if (_head == null)
				throw new InvalidOperationException("Stack is empty");
			
			return _head.Data;
		}

		//O(1)
		public T Pop()
		{
			if (_head == null)
				throw new InvalidOperationException("Stack is empty");

			var data = _head.Data;

			_head = _head.Next;
			Count--;

			return data;
		}

		public IEnumerator<T> GetEnumerator()
		{
			var current = _head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this).GetEnumerator();
		}
	}
}
