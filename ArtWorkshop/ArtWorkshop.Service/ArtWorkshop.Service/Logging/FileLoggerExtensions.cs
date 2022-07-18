using Microsoft.Extensions.Logging;

namespace ArtWorkshop.Service.Logging
{
	public static class FileLoggerExtensions
	{
		public static ILoggerFactory AddFile(this ILoggerFactory factory, string fileName)
		{
			factory.AddProvider(new FileLoggerProvider(fileName));
			return factory;
		}
	}
}
