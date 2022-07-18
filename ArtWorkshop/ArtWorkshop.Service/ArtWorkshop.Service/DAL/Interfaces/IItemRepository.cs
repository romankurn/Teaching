using ArtWorkshop.Service.DAL.Models.Item;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Interfaces
{
	public interface IItemRepository
	{
		Task CreateItemAsync(CreateItemDalModel dal);

		Task<IEnumerable<ItemDalModel>> GetItemsByOrderId(int orderId);

		Task<IEnumerable<ItemDalModel>> GetItemsByAuthorId(int workerId);

		Task<IEnumerable<ItemDalModel>> GetItemsByCustomerId(int customerId);

		Task<IEnumerable<ItemDalModel>> GetItemsWithoutAuthor();

		Task<int?> AssignAuthorToItem(AssignAuthorToItemDalModel dal);

		Task<int?> ChangeItemStatus(ChangeItemStatusDalModel dal);

		Task<int?> ChangeItemPrice(ChangeItemPriceDalModel dal);

		Task<int?> ChangeItemFinishDate(ChangeItemFinishDateDalModel dal);
	}
}
