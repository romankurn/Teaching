using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
	public class AdvansedCustomCollectionInt : AdvansedCustomCollection<int>
	{
		public AdvansedCustomCollectionInt(List<int> list) : base(list)
		{

		}
	}
}
