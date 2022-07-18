using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer
{
	public class TimeEventArgs : EventArgs
	{
		public int Seconds { get; set; }

		public int Minutes { get; set; }

		public int Hours { get; set; }

		public TimeEventArgs(int seconds, int minutes, int hours)
		{
			Seconds = seconds;
			Minutes = minutes;
			Hours = hours;
		}
	}
}
