using System;
using System.Collections.Generic;
using System.Threading;

namespace AlgorithmTester
{
	public class Tester
	{
		private TestParams _testParams;
		private IMaxValuePreparer _minMaxValuePreparer;

		public Tester(TestParams testParams, IMaxValuePreparer minMaxValuePreparer = null)
		{
			_testParams = testParams;
			_minMaxValuePreparer = minMaxValuePreparer;
		}

		private MeasurePoint MeasureTime(AlgorithmBase algorithm, int size)
		{
			var processingTime = new ProcessingTime();

			for (int i = 0; i < _testParams.AlgorithmRepeats; i++)
			{
				var maxValue = _minMaxValuePreparer?.FixMaxValue(size) ?? _testParams.MaxValue;

				processingTime.SaveTime(algorithm.DoTest(size, _testParams.MinValue, maxValue));
			}

			return new MeasurePoint {Name = algorithm.Name, DataSize = size, Time = processingTime.CalculateMeanTime() };
		}

		public List<MeasurePoint> TestAlgorithm(AlgorithmBase algorithm, ConsoleColor textColor = ConsoleColor.White)
		{
			var measurePoints = new List<MeasurePoint>();

			var deltaSize = (_testParams.FinaleDataSize - _testParams.InitialDataSize) / (_testParams.MeasurementsCount);

			for(var size = _testParams.InitialDataSize; size <= _testParams.FinaleDataSize; size += deltaSize)
			{
				Console.ForegroundColor = textColor;
				Console.Write($"{algorithm.Name}.{size}\t...\t");
				
				var measurePoint = MeasureTime(algorithm, size);

				measurePoints.Add(measurePoint);

				Console.ForegroundColor = textColor;
				Console.WriteLine($"{measurePoint.Time}\tms");
			}

			Console.ForegroundColor = textColor;
			Console.WriteLine("--------------------------------------------");

			return measurePoints;
		}
	}
}
