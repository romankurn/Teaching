using System;
using System.Collections;
using System.Collections.Generic;

namespace Polymorphism
{
	public class UniversityEnumerator : IEnumerator<Person>
	{
		private List<Person> _container;
		private int _position = -1;

		public UniversityEnumerator(List<Person> container)
		{
			_container = container;
		}

		public Person Current
		{
			get
			{
				if (_position < 0 || _position > _container.Count)
					throw new InvalidOperationException();

				return _container[_position];
			}
		}

		public bool MoveNext()
		{
			if (_position < _container.Count - 1)
			{
				_position++;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			_position = -1;
		}

		public void Dispose()
		{

		}

		object IEnumerator.Current => throw new NotImplementedException();
	}
}
