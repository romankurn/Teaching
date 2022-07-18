using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.RequestsHandler;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests
{
	public class SingOutRequest : IHandler
	{
		public async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage = null)
		{
			await botClient.SendTextMessageAsync(currentUser.TelegramId,
								$"Для начала работы используйте команду: /start", replyMarkup: new ReplyKeyboardRemove());

			currentUser.CurrentState = TelegramState.None;
		}
	}
}
