using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Structures
{
	public class CustomDeque<T> : IEnumerable<T>
	{
		private DoublyLinkedNode<T> _head;
		private DoublyLinkedNode<T> _tail;
		
		public int Count { get; private set; }

		public T First { get { return default(T); } }
		public T Last { get { return default(T); } }

		public void AddFirst(T Data)
		{ }

		public void AddLast(T Data)
		{ }

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public T RemoveFirst() { return default(T); }

		public T RemoveLast() { return default(T); }

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
