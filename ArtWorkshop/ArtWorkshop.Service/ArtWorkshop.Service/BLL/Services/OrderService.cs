using ArtWorkshop.Service.BLL.Enums;
using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Models.Order;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Models.Order;
using ArtWorkshop.Service.Exceptions.Order;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task ChangeOrderData(ChangeOrderDataModel dal)
		{
			var updatedRowCount = await _orderRepository.ChangeOrderData(new ChangeOrderDataDalModel
			{
				DeliveryFee = dal.DeliveryFee,
				DeliveryTypeId = dal.DeliveryTypeId,
				RecieverAddress = dal.RecieverAddress,
				Status = dal.Status?.ToString(),
				Id = dal.Id
			});

			if (!updatedRowCount.HasValue)
				throw new OrderDataHasNotBeenUpdatedException();
		}

		public async Task<int> CreateOrderAsync(CreateOrderModel model)
		{
			return (await _orderRepository.CreateOrderAsync(new CreateOrderDalModel
			{
				CustomerId = model.CustomerId,
				RecieverAddress = model.RecieverAddress,
				Status = OrderStatus.Init.ToString(),
			})).Value;
		}

		public async Task<IEnumerable<OrderModel>> GetOrdersByStatusAsync(string status)
		{
			var orders = await _orderRepository.GetOrdersByStatusAsync(status);

			return orders.Select(o => new OrderModel { Id = o.Id, DeliveryTypeId = o.DeliveryTypeId, CustomerId = o.CustomerId, DeliveryFee = o.DeliveryFee, RecieverAddress = o.RecieverAddress, Status = o.Status });
		}

		public async Task<IEnumerable<OrderModel>> GetOrdersByUserIdAsync(int userId)
		{
			var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);

			return orders.Select(o => new OrderModel { Id = o.Id, DeliveryTypeId = o.DeliveryTypeId, CustomerId = o.CustomerId, DeliveryFee = o.DeliveryFee, RecieverAddress = o.RecieverAddress, Status = o.Status });
		}
	}
}
