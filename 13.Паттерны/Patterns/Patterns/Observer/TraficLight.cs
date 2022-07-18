using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer
{
	public class TraficLight
	{
		private Timer _timer;

		private bool _isGreen;

		private bool _isRed;

		public TraficLight(Timer timer)
		{
			_timer = timer;

			_timer.OnStateChanged += CangeColor;
		}

		public void CangeColor(object sender, EventArgs e)
		{
			var time = e as TimeEventArgs;

			Console.WriteLine($"seconds: {time?.Seconds}");
			
			if (time?.Seconds % 5 == 0 && time?.Seconds % 2 != 0 && time?.Seconds %3 != 0)
			{
				_isRed = true;
				_isGreen = false;

				Console.WriteLine($"Red: {_isRed}");
			}
			
			if(time?.Seconds % 5 == 0 && time?.Seconds % 3 == 0)
			{
				_isRed = false;
				_isGreen = true;

				Console.WriteLine($"Green: {_isGreen}");
			}
		}
	}
}
