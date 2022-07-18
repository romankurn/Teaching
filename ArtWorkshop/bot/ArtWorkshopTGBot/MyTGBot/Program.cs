using ArtWorkshop.TGBot.Configuration;
using ArtWorkshop.TGBot.Telegram;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ArtWorkshop.TGBot
{
	public class Program
	{
		private readonly TelegramBotApi _telegramBotApi;

		public Program(TelegramBotApi telegramBotApi)
		{
			_telegramBotApi = telegramBotApi;
		}

		static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();
			host.Services.GetRequiredService<Program>().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder(args)
				.ConfigureServices(services => { })
				.UseStartup<Startup>();
		}

		public void Run()
		{
			_telegramBotApi.ConnectBot();

			Console.WriteLine($"Application is working...{Environment.NewLine}To exit enter any button");
			Console.ReadKey();
		}
	}
}
