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
	public class ChooseCanvasTypeRequest : RequestHandlerBase
	{
		private readonly PictureTypesStorage _pictureTypesStorage;

		public ChooseCanvasTypeRequest(IArtWorkshopClient artWorkshopClient, PictureTypesStorage pictureTypesStorage) : base(artWorkshopClient)
		{
			_pictureTypesStorage = pictureTypesStorage;
		}

		public override async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage)
		{
			currentUser.CurrentState = TelegramState.Customer_CreateNewOrder_СhoosePictureType;

			if (int.TryParse(requestMessage, out var canvasTypeId))
			{
				currentUser.UserRequests.CreatePictureRequest.CanvasTypeId = canvasTypeId;
			}			

			var answer = string.Join(Environment.NewLine, _pictureTypesStorage.PictureTypes.Select(s => $"{s.Key}) {s.Value.Name}"));

			answer = string.Concat($"Выберите нужный вам тип изображения и введите его номер:{Environment.NewLine}", answer);

			await botClient.SendTextMessageAsync(currentUser.TelegramId, answer, replyMarkup: new BackButton().Rkm, cancellationToken: cancellationToken);
		}
	}
}
