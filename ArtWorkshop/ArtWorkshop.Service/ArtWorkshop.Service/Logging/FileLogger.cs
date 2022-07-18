using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace ArtWorkshop.Service.Logging
{
	public class FileLogger : ILogger
	{
		private string _fileName;
		private static object _lock = new object();

		public FileLogger(string fileName)
		{
			_fileName = fileName;
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return null;
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return true;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			if (formatter != null)
			{
				lock (_lock)
				{
					File.AppendAllText(_fileName, formatter(state, exception) + Environment.NewLine);
				}
			}
		}
	}
}
