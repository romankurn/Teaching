using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
	public class LinkedList<T> : IEnumerable<T>
	{
		private Node<T> head;
		private Node<T> tail;

		public int Count { get; private set; }

		// O(1)
		public void AddLast(T data)
		{
			var node = new Node<T>(data);

			if (tail != null)
			{
				tail.Next = node;
			}
			else
			{
				head = node;
			}

			tail = node;
			Count++;
		}

		// O(1)
		public void AddFirst(T data)
		{
			var node = new Node<T>(data);

			if (head != null)
			{
				head.Next = node;
			}
			else
			{
				tail = node;
			}

			head = node;
			Count++;
		}

		// O(n)
		public bool Contains(T data)
		{
			var current = head;

			while (current != null)
			{
				if (current.Data.Equals(data))
					return true;

				current = current.Next;
			}

			return false;
		}

		//O(n)
		public bool Any(Func<T, bool> filter = null)
		{
			if (filter == null)
				return Count > 0;
			else
			{
				var current = head;

				while(current != null)
				{
					if (filter(current.Data))
						return true;

					current=current.Next;
				}

				return false;
			}
		}

		//O(n)
		public bool Remove(T data)
		{
			var current = head;

			if(Count == 1 && current.Data.Equals(data))
			{
				head = null;
				tail = null;
				Count--;
				return true;
			}

			if (current.Data.Equals(data))
			{
				head = current.Next;
				Count--;
				return true;
			}

			while (current != null)
			{
				if (current.Next?.Data.Equals(data) == true)
				{
					current.Next = current.Next.Next;

					if(current.Next == null)
					{
						tail = current;
					}
					Count--;
					return true;
				}
				current = current.Next;
			}

			return false;
		}

		public IEnumerator<T> GetEnumerator()
		{
			var current = head;
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
