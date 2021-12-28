using AlgorithmTester;
using SortAlgorithms;
using System;
using System.Threading.Tasks;

namespace BubleSort
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var csvCreator = new CsvCreator("MixedSortTimes.csv");

			var bubleSortAdapterOrigin = new BubbleSortAdapter("bubbleOrigin", false);
			var bubleSortAdapterBest = new BubbleSortAdapter("bubbleBest", true);
			var shakerSortAdapterOrigin = new ShakerSortAdapter("shakerOrigin", false);
			var shakerSortAdapterBest = new ShakerSortAdapter("shakerBest", true);

			var tester = new Tester(new TestParams 
			{ 
				AlgorithmRepeats = 5,
				MinValue = int.MinValue,
				MaxValue = int.MaxValue,
				InitialDataSize = 100,
				FinaleDataSize = 10000,
				MeasurementsCount = 99
			});

			var pointsBubbleOriginTask = Task.Run(() => tester.TestAlgorithm(bubleSortAdapterOrigin, ConsoleColor.Blue));
			var pointsShakerOriginTask = Task.Run(() => tester.TestAlgorithm(shakerSortAdapterOrigin, ConsoleColor.Red));

			var pointsBubbleBestTask = Task.Run(() => tester.TestAlgorithm(bubleSortAdapterBest, ConsoleColor.Cyan));
			var pointsShakerBestTask = Task.Run(() => tester.TestAlgorithm(shakerSortAdapterBest, ConsoleColor.Yellow));


			await Task.WhenAll(pointsBubbleOriginTask, pointsShakerOriginTask, pointsBubbleBestTask, pointsShakerBestTask);

			var pointsBubbleOrigin = pointsBubbleOriginTask.Result;
			var pointsShakerOrigin = pointsShakerOriginTask.Result;
			var pointsBubbleBest = pointsBubbleBestTask.Result;
			var pointsShakerBest = pointsShakerBestTask.Result;

			csvCreator.CreateFile(pointsBubbleOrigin, pointsShakerOrigin, pointsBubbleBest, pointsShakerBest);

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Done!");
		}
	}
}
