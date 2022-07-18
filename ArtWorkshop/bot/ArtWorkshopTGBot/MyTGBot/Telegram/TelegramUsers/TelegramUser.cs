using ArtWorkshop.TGBot.Telegram.Enums;
using System.Threading.Tasks;

namespace ArtWorkshop.TGBot.Telegram.TelegramUsers
{
	public class TelegramUser
	{
		public long TelegramId { get; private set; }

		public TelegramState CurrentState { get; set; }

		public Role UserRole { get; private set; }

		public int ServiceUserId { get; private set; }

		public UserRequests UserRequests { get; set; }

		public TelegramUser(long telegramId)
		{
			TelegramId = telegramId;
			CurrentState = TelegramState.None;
			UserRole = Role.Unauthorized;
			UserRequests = new UserRequests();
		}

		public void SetRole(Role role)
		{
			UserRole = role;
		}

		public void SetServiceUserId(int id)
		{
			ServiceUserId = id;
		}
	}
}
