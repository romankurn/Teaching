using ArtWorkshop.Service.BLL.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Interfaces
{
	public interface IOrderService
	{
		Task<int> CreateOrderAsync(CreateOrderModel model);

		Task<IEnumerable<OrderModel>> GetOrdersByUserIdAsync(int userId);

		Task<IEnumerable<OrderModel>> GetOrdersByStatusAsync(string status);

		Task ChangeOrderData(ChangeOrderDataModel dal);
	}
}
