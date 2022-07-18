using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.RequestsHandler;
using ArtWorkshop.TGBot.Telegram.Settings;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;

namespace ArtWorkshop.TGBot.Telegram
{
	public class TelegramBotApi
	{
		private readonly string _botKeyPath;

		private readonly RequestHeandler _requestHeandler;

		public TelegramBotApi(TelegramBotApiSettings settings, RequestHeandler requestHeandler)
		{
			_botKeyPath = settings.BotKeyPath;
			_requestHeandler = requestHeandler;
		}

		public void ConnectBot()
		{
			var botKey = File.ReadAllText(_botKeyPath);

			var allowedUpdates = new[] { UpdateType.Message };
			var receiverOptions = new ReceiverOptions { AllowedUpdates = allowedUpdates};

			var cts = new CancellationTokenSource();
			var cancellationToken = cts.Token;

			var bot = new TelegramBotClient(botKey);
			
			bot.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions, cancellationToken);
		}

		private Task ErrorHandler(ITelegramBotClient botClient, Exception ex, CancellationToken cancellationToken)
		{
			Console.WriteLine(ex.Message);
			return Task.CompletedTask;
		}

		private async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		{			
			try
			{
				if (update.Message == null)
					return;

				if (update.Message?.Text == null)
					return;

				var currentUser = ActiveTelegramUsers.GetOrAddUser(update.Message.Chat.Id);

				await _requestHeandler.HeandleRequest(currentUser, botClient, update.Message.Text, cancellationToken);
				return;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Message: {ex.Message}.{Environment.NewLine}DateTime: {DateTime.Now}{Environment.NewLine}");

				var currentUser = ActiveTelegramUsers.GetOrAddUser(update.Message.Chat.Id);

				await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Произошла неизвестная ошибка.");

				currentUser.CurrentState = TelegramState.None;
			}
		}
	}
}
