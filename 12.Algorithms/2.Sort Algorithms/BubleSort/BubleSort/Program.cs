using AlgorithmTester;
using SortAlgorithms;
using System;

namespace BubleSort
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var csvCreator = new CsvCreator("BubleSortTimes.csv");
			var bubleSortHelper = new BubleSortHelper();

			var tester = new Tester(new TestParams 
			{ 
				AlgorithmRepeats = 10,
				MinValue = int.MinValue,
				MaxValue = int.MaxValue,
				InitialDataSize = 1000,
				FinaleDataSize = 10000,
				MeasurementsCount = 9
			});

			var points = tester.TestAlgorithm(bubleSortHelper);
			csvCreator.CreateFile(points);

			Console.WriteLine("Done!");
		}
	}
}
