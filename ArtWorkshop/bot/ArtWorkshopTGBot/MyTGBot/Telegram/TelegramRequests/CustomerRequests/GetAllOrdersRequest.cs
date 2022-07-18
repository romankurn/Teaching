using ArtWorkshop.Client;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests.CustomerRequests
{
	public class GetAllOrdersRequest : RequestHandlerBase
	{
		public GetAllOrdersRequest(IArtWorkshopClient artWorkshopClient) : base(artWorkshopClient)
		{
		}

		public override async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage)
		{
			var response = await _artWorkshopClient.GetOrdersByUserId(currentUser.ServiceUserId, currentUser.ServiceUserId);
		}
	}
}
