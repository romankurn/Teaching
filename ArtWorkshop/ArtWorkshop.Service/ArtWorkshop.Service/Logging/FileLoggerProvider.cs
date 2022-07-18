using Microsoft.Extensions.Logging;

namespace ArtWorkshop.Service.Logging
{
	public class FileLoggerProvider : ILoggerProvider
	{
		private string _fileName;

		public FileLoggerProvider(string fileName)
		{
			_fileName = fileName;
		}

		public ILogger CreateLogger(string categoryName)
		{
			return new FileLogger(_fileName);
		}

		public void Dispose()
		{

		}
	}
}
