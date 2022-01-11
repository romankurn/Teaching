using AlgorithmTester;
using Newtonsoft.Json.Linq;
using SortAlgorithms;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BubleSort
{
	internal class Program
	{
		private static JObject m_settings;
		private static JObject Settings
		{
			get
			{
				if (m_settings != null)
					return m_settings;

				var configFile = File.ReadAllText("Config.json");
				m_settings = JObject.Parse(configFile);

				return m_settings;
			}
		} 

		static async Task Main(string[] args)
		{
			var csvCreator = new CsvCreator("ShakerVSInsertSortTimes.csv");

			var insertSortAdapterOrigin = new InsertSortAdapter("insertOrigin", false);
			var insertSortAdapterBest = new InsertSortAdapter("insertBest", true);
			var shakerSortAdapterOrigin = new ShakerSortAdapter("shakerOrigin", false);
			var shakerSortAdapterBest = new ShakerSortAdapter("shakerBest", true);

			var tester = new Tester(new TestParams 
			{ 
				AlgorithmRepeats = Settings["AlgorithmRepeats"].Value<int>(),
				MinValue = Settings["MinValue"].Value<int>(),
				MaxValue = Settings["MaxValue"].Value<int>(),
				InitialDataSize = Settings["InitialDataSize"].Value<int>(),
				FinaleDataSize = Settings["FinaleDataSize"].Value<int>(),
				MeasurementsCount = Settings["MeasurementsCount"].Value<int>()
			});

			var pointsInsertOriginTask = Task.Run(() => tester.TestAlgorithm(insertSortAdapterOrigin, ConsoleColor.Blue));
			var pointsShakerOriginTask = Task.Run(() => tester.TestAlgorithm(shakerSortAdapterOrigin, ConsoleColor.Red));

			var pointsInsertBestTask = Task.Run(() => tester.TestAlgorithm(insertSortAdapterBest, ConsoleColor.Cyan));
			var pointsShakerBestTask = Task.Run(() => tester.TestAlgorithm(shakerSortAdapterBest, ConsoleColor.Yellow));


			await Task.WhenAll(pointsInsertOriginTask, pointsShakerOriginTask, pointsInsertBestTask, pointsShakerBestTask);

			var pointsInsertOrigin = pointsInsertOriginTask.Result;
			var pointsShakerOrigin = pointsShakerOriginTask.Result;
			var pointsInsertBest = pointsInsertBestTask.Result;
			var pointsShakerBest = pointsShakerBestTask.Result;

			csvCreator.CreateFile(pointsInsertOrigin, pointsShakerOrigin, pointsInsertBest, pointsShakerBest);

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Done!");
		}
	}
}
