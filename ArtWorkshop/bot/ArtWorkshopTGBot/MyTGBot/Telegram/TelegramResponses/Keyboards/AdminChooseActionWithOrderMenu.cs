using Telegram.Bot.Types.ReplyMarkups;

namespace ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards
{
	public class AdminChooseActionWithOrderMenu
	{
		public ReplyKeyboardMarkup Rkm { get; private set; }

		public AdminChooseActionWithOrderMenu()
		{
			Rkm = new(new[]
		{
			new KeyboardButton[] { "Получить Id неподтверждённых заказов", "Назад"}			
		})
			{
				ResizeKeyboard = true,
				OneTimeKeyboard = true
			};
		}
	}
}
