using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing
{
	internal class MyObject
	{
		public int a;

		public override bool Equals(object obj)
		{
			if(obj == null)
				return false;

			return (obj as MyObject)?.a == a;
		}
	}
}
