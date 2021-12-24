using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTester
{
	public class ProcessingTime
	{
		private List<double> _times;

		public ProcessingTime()
		{
			_times = new List<double>();
		}

		public void SaveTime(double time)
		{
			_times.Add(time);
		}

		public double CalculateMeanTime()
		{
			return _times.Sum() / _times.Count;
		}
	}
}
