using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.RequestsHandler;
using ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests.SingUp
{
	public class SingUpRequest : IHandler
	{
		public async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage = null)
		{
			currentUser.CurrentState = TelegramState.SingUp;

			await botClient.SendTextMessageAsync(currentUser.TelegramId, "Введите ваш email, имя,фамилию и пароль для регистрации в формате: email/имя/фамилия/пароль/подтверждение пароля", replyMarkup: new BackButton().Rkm, cancellationToken: cancellationToken);
		}
	}
}
