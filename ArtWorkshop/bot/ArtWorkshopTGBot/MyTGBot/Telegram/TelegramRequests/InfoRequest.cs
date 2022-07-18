using ArtWorkshop.TGBot.Telegram.RequestsHandler;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests
{
	public class InfoRequest : IHandler
	{
		public async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage = null)
		{
			await botClient.SendTextMessageAsync(currentUser.TelegramId, "Информация о боте и мастерской");
		}
	}
}
