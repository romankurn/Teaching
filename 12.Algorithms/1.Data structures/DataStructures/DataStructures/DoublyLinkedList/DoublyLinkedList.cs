using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
	public class DoublyLinkedList<T> : IEnumerable<T>
	{
		private DoublyLinkedNode<T> head;
		private DoublyLinkedNode<T> tail;

		public int Count { get; private set; }

		// O(1)
		public void AddLast(T data)
		{
			var node = new DoublyLinkedNode<T>(data);

			if (tail != null)
			{
				node.Previous = tail;
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
			var node = new DoublyLinkedNode<T>(data);

			if (head != null)
			{
				node.Next = head;
				head.Previous = node;
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

				while (current != null)
				{
					if (filter(current.Data))
						return true;

					current = current.Next;
				}

				return false;
			}
		}

		//O(n)
		public bool Remove(T data)
		{
			var current = head;
			DoublyLinkedNode<T> previous = null;

			if (Count == 1 && current.Data.Equals(data))
			{
				head = null;
				tail = null;
				Count--;
				return true;
			}

			if (current.Data.Equals(data))
			{
				head = current.Next;
				current.Next.Previous = null;
				Count--;
				return true;
			}

			while (current != null)
			{
				if (current.Data.Equals(data))
				{
					if (current.Next == null)
					{
						tail = previous;
						previous.Next = null;
						// current.Previous = null; так надо?
						Count--;
						return true;
					}

					previous.Next = current.Next;
					current.Next.Previous = previous;
					Count--;
					return true;
				}

				previous = current;
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

		public IEnumerable<T> GetBackEnumerator()
		{
			var current = tail;
			while (current != null)
			{
				yield return current.Data;
				current = current.Previous;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this).GetEnumerator();
		}
	}
}
