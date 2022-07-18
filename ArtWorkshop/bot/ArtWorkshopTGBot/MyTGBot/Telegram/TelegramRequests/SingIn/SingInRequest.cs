using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.RequestsHandler;
using ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests.SingIn
{
	public class SingInRequest : IHandler
	{
		public async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage = null)
		{
			currentUser.CurrentState = TelegramState.SingIn;

			await botClient.SendTextMessageAsync(currentUser.TelegramId, "Введите ваш email и пароль в формате: email/пароль", replyMarkup: new BackButton().Rkm, cancellationToken: cancellationToken);
		}
	}
}
