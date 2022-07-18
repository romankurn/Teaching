using ArtWorkshop.Models.Enums;
using ArtWorkshop.Models.Requests.Order;
using ArtWorkshop.Models.Responses.Order;
using ArtWorkshop.Service.Autorization;
using ArtWorkshop.Service.BLL.Enums;
using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Models.Order;
using ArtWorkshop.Service.Exceptions.Order;
using ArtWorkshop.Service.Exceptions.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace ArtWorkshop.Service.Controllers
{
	[Route("api/order")]
	public class OrderController : Controller
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost("create")]
		[CustomAuthorize(Roles.Admin, Roles.Customer)]
		public async Task<ActionResult<CreateOrderResponse>> CreateOrder([FromBody] CreateOrderRequest request)
		{
			try
			{
				var createOrderModel = new CreateOrderModel
				{
					RecieverAddress = request.RecieverAddress,
					CustomerId = request.CustomerId
				};

				var orderId = await _orderService.CreateOrderAsync(createOrderModel);

				return Ok(new CreateOrderResponse { OrderId = orderId});
			}
			catch (InvalidCustomerIdException ex)
			{
				return BadRequest(ErrorCode.InvalidCustomerId.ToString());
			}
			catch (InvalidDeliveryTypeIdException ex)
			{
				return BadRequest(ErrorCode.InvalidDeliveryTypeId.ToString());
			}
		}

		[HttpGet("byUserId")]
		[CustomAuthorize(Roles.Admin, Roles.Customer)]
		public async Task<ActionResult<GetOrdersResponse>> GetOrdersByUserId([FromQuery] int customerId)
		{

			var result = await _orderService.GetOrdersByUserIdAsync(customerId);

			return Ok(new GetOrdersResponse
			{
				Orders = result.Select(r => new GetOrdersResponse.UserOrder
				{
					Id = r.Id,
					CustomerId = r.CustomerId,
					DeliveryFee = r.DeliveryFee,
					DeliveryTypeId = r.DeliveryTypeId,
					RecieverAddress = r.RecieverAddress,
					Status = r.Status
				})
			});

		}

		[HttpGet("byOrderStatus")]
		[CustomAuthorize(Roles.Admin, Roles.Customer)]
		public async Task<ActionResult<GetOrdersResponse>> GetOrdersByStatus([FromQuery] string status)
		{
			var result = await _orderService.GetOrdersByStatusAsync(status);

			return Ok(new GetOrdersResponse
			{
				Orders = result.Select(r => new GetOrdersResponse.UserOrder
				{
					Id = r.Id,
					CustomerId = r.CustomerId,
					DeliveryFee = r.DeliveryFee,
					DeliveryTypeId = r.DeliveryTypeId,
					RecieverAddress = r.RecieverAddress,
					Status = r.Status
				})
			});

		}

		[HttpPost("change")]
		[CustomAuthorize(Roles.Admin, Roles.Customer)]
		public async Task<ActionResult<ChangeOrderDataResponse>> ChangeOrderData([FromBody]ChangeOrderDataRequest request)
		{
			try
			{
				await _orderService.ChangeOrderData(new ChangeOrderDataModel
				{
					DeliveryFee = request.DeliveryFee,
					DeliveryTypeId = request.DeliveryTypeId,
					RecieverAddress = request.RecieverAddress,
					Status = !string.IsNullOrEmpty(request.Status) ? Enum.Parse<OrderStatus>(request.Status) : null,
					Id = request.Id
				});

				return Ok(new ChangeOrderDataResponse());
			}
			catch(InvalidDeliveryTypeIdException ex)
			{
				return BadRequest(ErrorCode.InvalidDeliveryTypeId.ToString());
			}
			catch(OrderDataHasNotBeenUpdatedException ex)
			{
				return BadRequest(ErrorCode.OrderDataHasNotBeenUpdated.ToString());
			}
			catch(ArgumentException ex)
			{
				return BadRequest(ErrorCode.IncorrectOrderStatus.ToString());
			}

		}
	}
}
