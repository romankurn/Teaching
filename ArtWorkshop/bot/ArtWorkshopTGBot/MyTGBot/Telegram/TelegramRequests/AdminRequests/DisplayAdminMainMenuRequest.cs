using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.RequestsHandler;
using ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests.AdminRequests
{
	public class DisplayAdminMainMenuRequest : IHandler
	{
		public async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage = null)
		{
			await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Выберите действие",
						replyMarkup: new AdminMainMenu().Rkm, cancellationToken: cancellationToken);

			currentUser.CurrentState = TelegramState.Admin_MainMenu;
		}
	}
}
