using ArtWorkshop.Client;
using ArtWorkshop.TGBot.Telegram.RequestsHandler;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests
{
	public abstract class RequestHandlerBase : IHandler
	{
		protected IArtWorkshopClient _artWorkshopClient;

		protected RequestHandlerBase(IArtWorkshopClient artWorkshopClient)
		{
			_artWorkshopClient = artWorkshopClient;
		}

		public abstract Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage);
	}
}
