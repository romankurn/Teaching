using ArtWorkshop.Client;
using ArtWorkshop.Models.Enums;
using ArtWorkshop.Models.Requests.User;
using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.ReplyKeyboardMarkups;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ArtWorkshop.TGBot.Telegram.TelegramRequests.SingUp
{
	public class TrySingUpRequest : RequestHandlerBase
	{
		public TrySingUpRequest(IArtWorkshopClient artWorkshopClient) : base(artWorkshopClient)
		{
		}

		public override async Task HandleAsync(TelegramUser currentUser, CancellationToken cancellationToken, ITelegramBotClient botClient, string requestMessage)
		{
			try
			{
				var registrationString = requestMessage.Split('/');

				await _artWorkshopClient.SignUp(new UserSignUpRequest { Email = registrationString[0], FirstName = registrationString[1], SecondName = registrationString[2], Password = registrationString[3], PasswordConfirm = registrationString[4] });

				currentUser.CurrentState = TelegramState.Authorization;

				await botClient.SendTextMessageAsync(currentUser.TelegramId,
						"Авторизация прошла успешно.",
						   replyMarkup: new AuthorizationKeyboard().Rkm, cancellationToken: cancellationToken);
			}
			catch (ArtWorkshopException ex)
			{
				if (ex.ErrorCode == ErrorCode.UserWithSameEmailAlreadyExists)
				{
					await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Указанный email уже используется.{Environment.NewLine}Введите ваш email, имя,фамилию и пароль для регистрации в формате: email/имя/фамилия/пароль/подтверждение пароля");
					return;
				}
			}
			catch (IndexOutOfRangeException)
			{
				await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Неверный формат вода данных.{Environment.NewLine}Введите ваш email, имя,фамилию и пароль для регистрации в формате: email/имя/фамилия/пароль/подтверждение пароля");
				return;
			}
			catch (ArgumentException)
			{
				await botClient.SendTextMessageAsync(currentUser.TelegramId,
						$"Неверный формат вода данных.{Environment.NewLine}Пароль должен содержать не мнее 8 символов, включая: маленькую и большую буквы, цифру, без пробелов.{Environment.NewLine}Введите ваш email, имя,фамилию и пароль для регистрации в формате: email/имя/фамилия/пароль/подтверждение пароля");
				return;
			}
		}
	}
}
