using ArtWorkshop.TGBot.Stogare;
using ArtWorkshop.TGBot.Telegram.TelegramRequests;
using ArtWorkshop.TGBot.Telegram.TelegramRequests.AdminRequests;
using ArtWorkshop.TGBot.Telegram.TelegramRequests.CustomerRequests.CreateOrder;
using ArtWorkshop.TGBot.Telegram.TelegramRequests.SingIn;
using ArtWorkshop.TGBot.Telegram.TelegramRequests.SingUp;
using Microsoft.Extensions.DependencyInjection;

namespace ArtWorkshop.TGBot.Configuration
{
	public static class ServiceCollectionExtension
	{
		public static void AddRequests(this IServiceCollection services)
		{
			services.AddSingleton<StartRequest>();
			services.AddSingleton<InfoRequest>();
			services.AddSingleton<SingInRequest>();
			services.AddSingleton<SingUpRequest>();
			services.AddSingleton<TrySingInRequest>();
			services.AddSingleton<TrySingUpRequest>();
			services.AddSingleton<CreateNewOrderRequest>();
			services.AddSingleton<СhooseSizeRequest>();
			services.AddSingleton<ChooseCanvasTypeRequest>();
			services.AddSingleton<ChoosePictureTypeRequest>();
			services.AddSingleton<TryCreateNewOrderRequest>();
			services.AddSingleton<GetAllInitStatusOrdersRequest>();
			services.AddSingleton<SingOutRequest>();
			services.AddSingleton<DisplayAdminMainMenuRequest>();
		}

		public static void AddStorages(this IServiceCollection services)
		{
			services.AddSingleton<SizesStorage>();
			services.AddSingleton<CanvasTypesStorage>();
			services.AddSingleton<PictureTypesStorage>();
			services.AddSingleton<GildingTypeStorage>();
		}
	}
}
