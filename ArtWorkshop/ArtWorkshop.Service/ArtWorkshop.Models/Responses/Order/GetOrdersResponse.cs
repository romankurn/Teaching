using System.Collections.Generic;

namespace ArtWorkshop.Models.Responses.Order
{
	public class GetOrdersResponse
	{
		public IEnumerable<UserOrder> Orders { get; set; }

		public class UserOrder
		{
			public int Id { get; set; }

			public int CustomerId { get; set; }

			public string Status { get; set; }

			public int? DeliveryTypeId { get; set; }

			public string RecieverAddress { get; set; }

			public int? DeliveryFee { get; set; }
		}
	}
}
