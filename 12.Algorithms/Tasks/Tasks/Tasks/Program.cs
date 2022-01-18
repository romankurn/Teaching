using AlgorithmTester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var csvCreator = new CsvCreator("SortByRepetitions2.csv");

			var sortByRepetitionsOrigin1 = new SorterAdapter("Origin1", false);
			var sortByRepetitionsBest1 = new SorterAdapter("Best1", false);

			var sortByRepetitionsOrigin2 = new SorterAdapter2("Origin2", false);
			var sortByRepetitionsBest2 = new SorterAdapter2("Best2", false);

			var testerOrigin = new Tester(new TestParams
			{
				AlgorithmRepeats = 5,
				MinValue = 1,
				MaxValue = 100,
				InitialDataSize = 100,
				FinaleDataSize = 10000,
				MeasurementsCount = 99
			},
			   new MaxValuePreparerForSorter());

			var testerBest = new Tester(new TestParams
			{
				AlgorithmRepeats = 5,
				MinValue = 1,
				MaxValue = 100,
				InitialDataSize = 100,
				FinaleDataSize = 10000,
				MeasurementsCount = 99
			});

			var sortByRepetitionsOriginTask1 = Task.Run(() => testerOrigin.TestAlgorithm(sortByRepetitionsOrigin1, ConsoleColor.Blue));
			var sortByRepetitionsBestTask1 = Task.Run(() => testerBest.TestAlgorithm(sortByRepetitionsBest1, ConsoleColor.Red));

			var sortByRepetitionsOriginTask2 = Task.Run(() => testerOrigin.TestAlgorithm(sortByRepetitionsOrigin2, ConsoleColor.Green));
			var sortByRepetitionsBestTask2 = Task.Run(() => testerBest.TestAlgorithm(sortByRepetitionsBest2, ConsoleColor.Magenta));

			await Task.WhenAll(sortByRepetitionsOriginTask1, sortByRepetitionsBestTask1, sortByRepetitionsOriginTask2, sortByRepetitionsBestTask2);

			var pointsOrigin1 = sortByRepetitionsOriginTask1.Result;
			var pointsBest1 = sortByRepetitionsBestTask1.Result;
			var pointsOrigin2 = sortByRepetitionsOriginTask2.Result;
			var pointsBest2 = sortByRepetitionsBestTask2.Result;

			csvCreator.CreateFile(pointsOrigin1, pointsBest1, pointsOrigin2, pointsBest2);

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Done!");
		}

		/// <summary>
		/// Array contains numbers from 0 to 100
		/// отсортировать в порядке убывания количества повторений каждого числа
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		//static int[] GetSordedByCount(int[] array)
		//{
		//	// 1 2 5 1 5 1 1 2 3 5
		//	// 1 1 1 1 5 5 5 2 2 3
		//}
	}
}
