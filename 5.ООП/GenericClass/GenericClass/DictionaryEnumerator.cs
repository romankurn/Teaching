using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass
{
	internal class DictionaryEnumerator<TKey, TValue> : IEnumerator<MyKeyValue<TKey, TValue>>
	{
		private List<MyKeyValue<TKey, TValue>> _container;
		private int _position = -1;

		public DictionaryEnumerator(List<MyKeyValue<TKey, TValue>> container)
		{
			_container = container;
		}

		public MyKeyValue<TKey, TValue> Current
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

		object IEnumerator.Current => throw new NotImplementedException();

		public void Dispose()
		{

		}
	}
}
