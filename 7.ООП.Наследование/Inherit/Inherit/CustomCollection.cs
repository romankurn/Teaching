using System.Collections.Generic;

namespace Inherit
{
	public class CustomCollection<Type>
	{
		protected List<Type> _list = new List<Type>();

		public CustomCollection(List<Type> list)
		{
			_list = list;
		}

		public void Add(Type item)
		{
			_list.Add(item);
		}

		public Type Get(int index)
		{
			return _list[index];
		}
	}
}
