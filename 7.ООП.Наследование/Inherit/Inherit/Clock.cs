using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inherit
{
	public class Clock
	{
		private byte _hours;

		public byte Seconds { get; set; }
		public byte Minutes { get; set; }
		public byte Hours 
		{ 
			get 
			{ 
				return _hours;
			} 
			set 
			{
				_hours = (byte)(value % 12);
			} 
		}

		public Clock(byte hours, byte minutes, byte seconds)
		{
			Seconds = seconds;
			Minutes = minutes;
			Hours = hours; 
		}

		public void Display()
		{
			Console.WriteLine($"{Hours}:{Minutes}:{Seconds}");
		}

		public static implicit operator int(Clock clock)
		{
			return clock.Hours * 3600 + clock.Minutes * 60 + clock.Seconds;
		}

		public static explicit operator Clock(int totalSeconds)
		{
			var hours = totalSeconds / 3600;
			var minutes = (totalSeconds % 3600) / 60;
			var seconds = totalSeconds % 60;

			return new Clock((byte)hours, (byte)minutes, (byte)seconds);
		}
	}
}
