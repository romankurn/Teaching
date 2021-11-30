using System;
using System.Collections;
using System.Collections.Generic;

namespace Implementation
{
	public class CustomCollection
	{
		private List<int> _container;

		public CustomCollection()
		{
			_container = new List<int>();
		}

		public CustomCollection(List<int> list)
		{
			_container = list;
		}

		public void Add(int item)
		{
			_container.Add(item);
		}

		public IEnumerator<int> GetEnumerator()
		{
			return new CuslomCollectionEnumerator(_container);
		}

	}
}
