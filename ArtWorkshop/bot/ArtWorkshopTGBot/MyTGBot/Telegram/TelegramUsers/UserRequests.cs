using ArtWorkshop.Models.Requests.Item;
using ArtWorkshop.Models.Requests.Picture;

namespace ArtWorkshop.TGBot.Telegram.TelegramUsers
{
	public class UserRequests
	{
		public CreatePictureRequest CreatePictureRequest { get; set; }

		public UserRequests()
		{
			CreatePictureRequest = new CreatePictureRequest();			
		}
	}
}
