using Telegram.Bot.Types.ReplyMarkups;

namespace ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards
{
	public class AdminMainMenu
	{
		public ReplyKeyboardMarkup Rkm { get; private set; }

		public AdminMainMenu()
		{
			Rkm = new(new[]
			{
			new KeyboardButton[] {"Работа с существующими заказами...", "Выйти" }
			 })
			{
				ResizeKeyboard = true,
				OneTimeKeyboard = true
			};
		}
	}
}
