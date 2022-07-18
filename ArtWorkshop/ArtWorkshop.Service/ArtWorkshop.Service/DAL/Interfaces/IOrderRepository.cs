using ArtWorkshop.Service.DAL.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Interfaces
{
	public interface IOrderRepository
	{
		Task<int?> CreateOrderAsync(CreateOrderDalModel dal);

		Task<IEnumerable<OrderDalModel>> GetOrdersByUserIdAsync(int id);

		Task<IEnumerable<OrderDalModel>> GetOrdersByStatusAsync(string status);

		Task<int?> ChangeOrderData(ChangeOrderDataDalModel dal);
	}
}
