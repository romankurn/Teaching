using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.ReplyKeyboardMarkups;
using ArtWorkshop.TGBot.Telegram.RequestsHandler;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests
{
	public class StartRequest : IHandler
	{
		public async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage = null)
		{
			currentUser.CurrentState = TelegramState.Authorization;

			await botClient.SendTextMessageAsync(currentUser.TelegramId,
							"Приветствие. Авторизуйтесь или Зарегистрируйтесь, для продолжения работы, для получения информации о боте нажмите Инфо",
							replyMarkup: new AuthorizationKeyboard().Rkm, cancellationToken: cancellationToken);
		}
	}
}
