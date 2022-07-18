using ArtWorkshop.Client;
using ArtWorkshop.TGBot.Stogare;
using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests.CustomerRequests.CreateOrder
{
	public class CreateNewOrderRequest : RequestHandlerBase
	{
		private readonly SizesStorage _sizesStorage;

		public CreateNewOrderRequest(IArtWorkshopClient artWorkshopClient, SizesStorage sizesStorage) : base(artWorkshopClient)
		{
			_sizesStorage = sizesStorage;
		}

		public override async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage)
		{
			currentUser.CurrentState = TelegramState.Customer_CreateNewOrder_СhooseSize;

			var answer = string.Join(Environment.NewLine, _sizesStorage.Sizes.Select(s => $"{s.Key}) {s.Value.Size}"));

			answer = string.Concat($"Выберите нужный вам размер и введите его номер:{Environment.NewLine}", answer);

			await botClient.SendTextMessageAsync(currentUser.TelegramId, answer, replyMarkup: new BackButton().Rkm, cancellationToken: cancellationToken);
		}
	}
}
