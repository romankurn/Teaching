using ArtWorkshop.Client;
using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests.AdminRequests
{
	public class GetAllInitStatusOrdersRequest : RequestHandlerBase
	{
		public GetAllInitStatusOrdersRequest(IArtWorkshopClient artWorkshopClient) : base(artWorkshopClient)
		{
		}

		public override async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage)
		{
			var orders = (await _artWorkshopClient.GetOrdersByStatus(OrderStatus.Init.ToString(), currentUser.ServiceUserId)).Orders;

			if(!orders.Any())
			{
				await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Удовлетворяющих запросу заказов не найдено.{Environment.NewLine}Выберите действие:",
						replyMarkup: new AdminChooseActionWithOrderMenu().Rkm, cancellationToken: cancellationToken); ;

				currentUser.CurrentState = TelegramState.Admin_ChooseActionWithOrder_Menu;
			}

			var str = new StringBuilder();

			str.AppendLine("OrdersId:") ;

			foreach (var order in orders)
			{
				str.AppendLine($"{order.Id}");
			}

			await botClient.SendTextMessageAsync(currentUser.TelegramId, str.ToString());

			await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Выберите действие",
						replyMarkup: new AdminMainMenu().Rkm, cancellationToken: cancellationToken);

			currentUser.CurrentState = TelegramState.Admin_MainMenu;
		}
	}
}
