using ArtWorkshop.Client;
using ArtWorkshop.Models.Enums;
using ArtWorkshop.Models.Requests.User;
using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests.SingIn
{
	public class TrySingInRequest : RequestHandlerBase
	{
		public TrySingInRequest(IArtWorkshopClient artWorkshopClient) : base(artWorkshopClient)
		{
		}

		public override async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage)
		{
			try
			{
				var authorizationString = requestMessage.Split('/');

				var response = await _artWorkshopClient.SignIn(new UserSignInRequest { Email = authorizationString[0], Password = authorizationString[1] });

				currentUser.SetRole(Enum.Parse<Role>(response.Role));
				currentUser.SetServiceUserId(response.Id);

				if (currentUser.UserRole == Role.Customer)
				{
					await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Успешная авторизация.{Environment.NewLine}Выберите действие",
						replyMarkup: new CustomerMainMenu().Rkm, cancellationToken: cancellationToken);

					currentUser.CurrentState = TelegramState.Customer_MainMenu;
				}

				if (currentUser.UserRole == Role.Admin)
				{
					await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Успешная авторизация.{Environment.NewLine}Выберите действие",
						replyMarkup: new AdminMainMenu().Rkm, cancellationToken: cancellationToken);

					currentUser.CurrentState = TelegramState.Admin_MainMenu;
				}
			}
			catch (ArtWorkshopException ex)
			{
				if (ex.ErrorCode == ErrorCode.UserNotFound)
				{
					await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Пользователь не найден.{Environment.NewLine}Зарегистрируйтесь или введите ваш email и пароль в формате: email/пароль");
					return;
				}

				if (ex.ErrorCode == ErrorCode.IncorrectPassword)
				{
					await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Неверный пароль.{Environment.NewLine}Введите ваш email и пароль в формате: email/пароль");
					return;
				}
			}
			catch (IndexOutOfRangeException)
			{
				await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Неверный формат вода данных.{Environment.NewLine}Введите ваш email и пароль в формате: email/пароль");
				return;
			}
		}
	}
}
