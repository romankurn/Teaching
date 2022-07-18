using ArtWorkshop.Service.BLL.Models.Item;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Interfaces
{
	public interface IItemService
	{
		Task CreateItemAsync(CreateItemModel model);
	}
}
