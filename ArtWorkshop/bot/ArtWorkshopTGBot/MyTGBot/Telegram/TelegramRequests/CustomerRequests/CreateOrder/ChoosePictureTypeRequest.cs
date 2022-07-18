using ArtWorkshop.Client;
using ArtWorkshop.TGBot.Stogare;
using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests.CustomerRequests.CreateOrder
{
	public class ChoosePictureTypeRequest : RequestHandlerBase
	{
		private GildingTypeStorage _gildingTypeStorage;
		private PictureTypesStorage _pictureTypesStorage;

		public ChoosePictureTypeRequest(IArtWorkshopClient artWorkshopClient, GildingTypeStorage gildingTypeStorage, PictureTypesStorage pictureTypesStorage) : base(artWorkshopClient)
		{
			_gildingTypeStorage = gildingTypeStorage;
			_pictureTypesStorage = pictureTypesStorage;
		}

		public override async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage)
		{
			currentUser.CurrentState = TelegramState.Customer_CreateNewOrder_СhooseGildingType;

			if (int.TryParse(requestMessage, out var pictureTypeId))
			{
				currentUser.UserRequests.CreatePictureRequest.PictureTypeId = pictureTypeId;

				var pictureTypeName = $"{_pictureTypesStorage.PictureTypes.TryGetValue(pictureTypeId, out var value)}";

				currentUser.UserRequests.CreatePictureRequest.Name = $"{value.Name}.{currentUser.ServiceUserId}";
			}			

			var answer = string.Join(Environment.NewLine, _gildingTypeStorage.GildingTypes.Select(s => $"{s.Key}) {s.Value.Name}"));

			answer = string.Concat($"Выберите нужный вам тип украшения и введите его номер:{Environment.NewLine}", answer);

			await botClient.SendTextMessageAsync(currentUser.TelegramId, answer);
		}
	}
}
