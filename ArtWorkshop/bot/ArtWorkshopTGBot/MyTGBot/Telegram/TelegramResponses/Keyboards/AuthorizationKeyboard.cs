using Telegram.Bot.Types.ReplyMarkups;

namespace ArtWorkshop.TGBot.Telegram.ReplyKeyboardMarkups
{
	public class AuthorizationKeyboard
	{
		public ReplyKeyboardMarkup Rkm { get; private set; }

		public AuthorizationKeyboard()
		{
			Rkm = new(new[]
		{
			new KeyboardButton[] {"Авторизоваться", "Зарегистрироваться"},
			new KeyboardButton[] {"Информация"}
		})
			{
				ResizeKeyboard = true,
				OneTimeKeyboard = true
			};
		}
	}
}
