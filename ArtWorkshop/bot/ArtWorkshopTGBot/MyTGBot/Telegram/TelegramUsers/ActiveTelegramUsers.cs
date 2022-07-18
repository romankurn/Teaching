using System.Collections.Concurrent;
using System.Linq;

namespace ArtWorkshop.TGBot.Telegram.TelegramUsers
{
	public static class ActiveTelegramUsers
	{
		private static ConcurrentBag<TelegramUser> _activeUsers = new();

		public static TelegramUser GetOrAddUser(long telegramId)
		{
			var telegramUser = _activeUsers.FirstOrDefault(x => x.TelegramId == telegramId);

			if (telegramUser != null)
				return telegramUser;

			var newTelegramUser = new TelegramUser(telegramId);
			_activeUsers.Add(newTelegramUser);

			return newTelegramUser;
		}
	}
}
