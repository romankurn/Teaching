using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
	public class CustomQueue<T> : IEnumerable<T>
	{
		private Node<T> _head;
		private Node<T> _tail;

		public int Count { get; private set; }
		public T First
		{
			get 
			{
				if (_head == null)
					throw new InvalidOperationException("Queue is empty");

				return _head.Data; 
			}
		}

		public T Last
		{
			get 
			{
				if (_tail == null)
					throw new InvalidOperationException("Queue is empty");

				return _tail.Data; 
			}
		}

		//O(1)
		public void Enqueue(T data)
		{
			var node = new Node<T>(data);

			if(_tail == null)
			{
				_head = node;
			}
			else
			{
				_tail.Next = node;
			}

			_tail = node;
			Count++;
		}

		//O(1)
		public T Dequeue()
		{
			if (_head == null)
				throw new InvalidOperationException("Queue is empty");

			var data = _head.Data;

			_head = _head.Next;

			Count--;
			return data;
		}

		public T Peek()
		{
			if (_head == null)
				throw new InvalidOperationException("Queue is empty");

			return _head.Data;
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
