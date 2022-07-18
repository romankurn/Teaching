using ArtWorkshop.Client;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.RequestsHandler
{
	public interface IHandler
	{
		Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage = null);

	}
}
