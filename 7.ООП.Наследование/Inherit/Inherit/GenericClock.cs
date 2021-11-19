using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
	public class GenericClock<Type> : Clock
	{
		Type Something { get; set; }

		public GenericClock(byte hours, byte minutes, byte seconds, Type something) : base(hours, minutes, seconds)
		{
			Something = something;
		}
	}
}
