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
	public class СhooseSizeRequest : RequestHandlerBase
	{
		public CanvasTypesStorage _canvasTypesStorage;

		public СhooseSizeRequest(IArtWorkshopClient artWorkshopClient, CanvasTypesStorage canvasTypesStorage) : base(artWorkshopClient)
		{
			_canvasTypesStorage = canvasTypesStorage;
		}

		public override async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage)
		{
			currentUser.CurrentState = TelegramState.Customer_CreateNewOrder_СhooseCanvasType;

			if (int.TryParse(requestMessage, out var sizeId))
			{
				currentUser.UserRequests.CreatePictureRequest.SizeId = sizeId;
			}

			var answer = string.Join(Environment.NewLine, _canvasTypesStorage.CanvasTypes.Select(s => $"{s.Key}) {s.Value.Name}"));

			answer = string.Concat($"Выберите нужный вам тип полотна и введите его номер:{Environment.NewLine}", answer);

			await botClient.SendTextMessageAsync(currentUser.TelegramId, answer, replyMarkup: new BackButton().Rkm, cancellationToken: cancellationToken);
		}
	}
}
