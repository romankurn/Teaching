using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.Observer
{
	public class Timer : INotifier
	{
		public event EventHandler OnStateChanged;

		public int Seconds => _totalSeconds % 60;

		public int Minutes => _totalSeconds / 60;

		public int Hours => _totalSeconds / 3600;

		private int _totalSeconds;

		private bool _isStoped;

		public Timer(int seconds = 0)
		{
			_totalSeconds = seconds;
		}

		public void Start()
		{
			_isStoped = false;
			CountSeconds();
		}

		public void Pause()
		{
			_isStoped = true;
		}

		public void Stop()
		{
			_isStoped = true;
			_totalSeconds = 0;
		}

		private async Task CountSeconds()
		{
			while (!_isStoped)
			{
				await Task.Delay(1000);
				
				if (_isStoped) 
					return;

				_totalSeconds++;

				OnStateChanged?.Invoke(this, new TimeEventArgs(Seconds, Minutes, Hours));
			}
		}
	}
}
