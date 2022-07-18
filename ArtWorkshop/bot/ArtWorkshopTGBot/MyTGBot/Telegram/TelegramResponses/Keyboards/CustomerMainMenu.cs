using Telegram.Bot.Types.ReplyMarkups;

namespace ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards
{
	public class CustomerMainMenu
	{
		public ReplyKeyboardMarkup Rkm { get; private set; }

		public CustomerMainMenu()
		{
			Rkm = new(new[]
		{
			new KeyboardButton[] {"Создать новый заказ", "Выйти"}
		})
			{
				ResizeKeyboard = true,
				OneTimeKeyboard = true
			};
		}
	}
}
