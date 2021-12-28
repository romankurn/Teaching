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

		public void CreateFile(params List<MeasurePoint>[] measurePointsParams)
		{
			var file = new FileInfo(_fileName);
			using(var writeText = file.AppendText())
			{
				writeText.Write("Size;");

				foreach(var measurePointList in measurePointsParams)
				{
					writeText.Write($"{measurePointList[0].Name}.Time;");
				}
				writeText.WriteLine();

				for(var measureNumber = 0; measureNumber < measurePointsParams[0].Count; measureNumber++)
				{
					writeText.Write($"{measurePointsParams[0][measureNumber].DataSize};");
					for (var columnNumber = 0; columnNumber < measurePointsParams.Length; columnNumber++)
					{
						writeText.Write($"{measurePointsParams[columnNumber][measureNumber].Time};");
					}
					writeText.WriteLine();
				}
			}


		}
	}
}
