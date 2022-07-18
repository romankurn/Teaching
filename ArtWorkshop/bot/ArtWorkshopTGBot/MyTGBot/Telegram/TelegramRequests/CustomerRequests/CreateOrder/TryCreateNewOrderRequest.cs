using ArtWorkshop.Client;
using ArtWorkshop.Models.Requests.Item;
using ArtWorkshop.Models.Requests.Order;
using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests.CustomerRequests.CreateOrder
{
	public class TryCreateNewOrderRequest : RequestHandlerBase
	{
		public TryCreateNewOrderRequest(IArtWorkshopClient artWorkshopClient) : base(artWorkshopClient)
		{
		}

		public override async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage)
		{
			try
			{
				currentUser.UserRequests.CreatePictureRequest.GildingTypeId = int.Parse(requestMessage);

				var pictureId = (await _artWorkshopClient.CreatePicture(currentUser.UserRequests.CreatePictureRequest, currentUser.ServiceUserId)).PictureId;

				var orderId = (await _artWorkshopClient.CreateOrder(new CreateOrderRequest
				{
					CustomerId = currentUser.ServiceUserId
				}, currentUser.ServiceUserId)).OrderId;

				await _artWorkshopClient.CreateItem(new CreateItemRequest
				{
					OrderId = orderId,
					PictureId = pictureId
				}, currentUser.ServiceUserId);

				await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Заказ создан успешно. Id вашего заказа: {orderId}");
			}
			catch (ArtWorkshopException)
			{
				await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Неудалось создать заказ.{Environment.NewLine}Выберите действие",
						replyMarkup: new CustomerMainMenu().Rkm, cancellationToken: cancellationToken);

				currentUser.CurrentState = TelegramState.Customer_MainMenu;
			}
			finally
			{
				await botClient.SendTextMessageAsync(currentUser.TelegramId,
						"Выберите действие",
						replyMarkup: new CustomerMainMenu().Rkm, cancellationToken: cancellationToken);

				currentUser.CurrentState = TelegramState.Customer_MainMenu;
			}
		}
	}
}
