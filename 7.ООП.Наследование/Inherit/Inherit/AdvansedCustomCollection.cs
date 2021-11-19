using System.Collections.Generic;

namespace Inherit
{
	public class AdvansedCustomCollection<Type> : CustomCollection<Type>
	{
		public int Count => _list.Count;

		public AdvansedCustomCollection(List<Type> list) : base(list)
		{

		}

		public void Remove(int index)
		{
			_list.RemoveAt(index);
		}
	}
}
