using System.Collections.Generic;
using System.IO;

namespace AlgorithmTester
{
	public class CsvCreator
	{
		private readonly string _fileName;

		public CsvCreator(string fileName)
		{
			_fileName = fileName;
		}

		public void CreateFile(List<MeasurePoint> measurePoints)
		{
			var file = new FileInfo(_fileName);
			using(var writeText = file.AppendText())
			{
				foreach(var measurePoint in measurePoints)
				{
					writeText.WriteLine($"{measurePoint.DataSize};{measurePoint.Time}");
				}
			}
		}
	}
}
