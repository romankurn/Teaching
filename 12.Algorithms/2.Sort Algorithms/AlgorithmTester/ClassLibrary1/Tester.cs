using System;
using System.Collections.Generic;

namespace AlgorithmTester
{
	public class Tester
	{
		private TestParams _testParams;

		public Tester(TestParams testParams)
		{
			_testParams = testParams;
		}

		private MeasurePoint MeasureTime(AlgorithmBase algorithm, int size)
		{
			var processingTime = new ProcessingTime();

			for (int i = 0; i < _testParams.AlgorithmRepeats; i++)
			{
				processingTime.SaveTime(algorithm.DoTest(size, _testParams.MinValue, _testParams.MaxValue));
			}

			return new MeasurePoint { DataSize = size, Time = processingTime.CalculateMeanTime() };
		}

		public List<MeasurePoint> TestAlgorithm(AlgorithmBase algorithm)
		{
			var measurePoints = new List<MeasurePoint>();

			var deltaSize = (_testParams.FinaleDataSize - _testParams.InitialDataSize) / (_testParams.MeasurementsCount);

			for(var size = _testParams.InitialDataSize; size <= _testParams.FinaleDataSize; size += deltaSize)
			{
				measurePoints.Add(MeasureTime(algorithm, size));
				Console.WriteLine($"{size}...");
			}

			return measurePoints;
		}
	}
}
