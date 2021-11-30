using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
	public class CuslomCollectionEnumerator : IEnumerator<int>
	{
		/////////////////////////////

		private List<int> _container;
		private int _position = -1;

		public CuslomCollectionEnumerator(List<int> container)
		{
			_container = container;
		}

		public int Current
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
