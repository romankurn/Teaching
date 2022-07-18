using ArtWorkshop.Client;
using ArtWorkshop.TGBot.Telegram;
using ArtWorkshop.TGBot.Telegram.RequestsHandler;
using ArtWorkshop.TGBot.Telegram.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace ArtWorkshop.TGBot.Configuration
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			var telegramBotApiSettings = Configuration.GetSection(nameof(TelegramBotApiSettings)).Get<TelegramBotApiSettings>();

			var serviceUrl = Configuration.GetSection("ServiceHosts")["ArtWorkshopServiceUrl"];
			var httpClient = new HttpClient { BaseAddress = new Uri(serviceUrl) };


			services.AddSingleton(httpClient);
			services.AddSingleton<IArtWorkshopClient, ArtWorkshopClient>();
			services.AddSingleton(telegramBotApiSettings);

			services.AddSingleton<RequestHeandler>();

			services.AddTransient<Program>();
			services.AddSingleton<TelegramBotApi>();

			services.AddStorages();
			services.AddRequests();
		}
	}
}
