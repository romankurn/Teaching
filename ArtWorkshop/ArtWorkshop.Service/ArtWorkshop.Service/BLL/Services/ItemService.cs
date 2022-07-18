using ArtWorkshop.Service.BLL.Enums;
using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Models.Item;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Models.Item;
using System;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Services
{
	public class ItemService : IItemService
	{
		private readonly IItemRepository _itemRepository;

		public ItemService(IItemRepository itemRepository)
		{
			_itemRepository = itemRepository;
		}

		public async Task CreateItemAsync(CreateItemModel model)
		{
			await _itemRepository.CreateItemAsync(new CreateItemDalModel
			{
				OrderId = model.OrderId,
				PictureId = model.PictureId,
				StartDate = DateTime.Now,
				Status = ItemStatus.Init.ToString()
			});
		}
	}
}
