using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Tasks1
{
	internal class Program
	{
		
		
		static void Main(string[] args)
		{
			var name = "NotOrderedFile.txt";

			var stopwatch = new Stopwatch();

			stopwatch.Start();
			SortFile(name);
			stopwatch.Stop();

			Console.WriteLine(stopwatch.ElapsedMilliseconds);
		}

		static void SortFile(string name)
		{
			var dictionary = new ConcurrentDictionary<string, long>();

			Parallel.ForEach(File.ReadLines(name), new ParallelOptions { MaxDegreeOfParallelism = 6 }, line => 
			{
				dictionary.AddOrUpdate(line, 1, (key, current) => current + 1);
			});

			//foreach (var line in File.ReadLines(name))
			//{
			//	dictionary.AddOrUpdate(line, 1, (key, current) => current + 1);
			//}

			var file = new StreamWriter("OrderedFile.txt");
			for (var currentByte = 0; currentByte < 256; currentByte++)
			{
				if (dictionary.TryGetValue(currentByte.ToString(), out long byteCount))
				{
					for (var i = 0; i < byteCount; i++)
					{						
						file.WriteLine(currentByte);
					}
				}
			}
			file.Close();
		}

		static void CreateBytes()
		{
			var capasity = 10000000;
			var random = new Random();

			var file = new StreamWriter("NotOrderedFile.txt");
			for (var i = 0; i < capasity; i++)
			{
				var byten = random.Next(0, 256);
				file.WriteLine(byten);
			}
			file.Close();
		}

		static int CountOnes()
		{
			var maxSetLenght = 1;
			var currentSetLenght = 1;
			var previousElement = "-";

			foreach (var line in File.ReadLines("bytes.txt"))
			{
				if(previousElement != line)
				{
					if (currentSetLenght > maxSetLenght)
						maxSetLenght = currentSetLenght;

					previousElement = line;
					currentSetLenght = 1;
				}
				else
				{
					currentSetLenght++;
				}
			}

			return maxSetLenght;
		}
	}
}
