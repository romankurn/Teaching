using Telegram.Bot.Types.ReplyMarkups;

namespace ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards
{
	public class BackButton
	{
		public ReplyKeyboardMarkup Rkm { get; private set; }

		public BackButton()
		{
			Rkm = new(new[]
		{
			new KeyboardButton[] {"Назад"}
		})
			{
				ResizeKeyboard = true,
				OneTimeKeyboard = true
			};
		}
	}
}
