using ArtWorkshop.Service.BLL.Enums;

namespace ArtWorkshop.Service.BLL.Models.Order
{
	public class ChangeOrderDataModel
	{
		public int Id { get; set; }

		public OrderStatus? Status { get; set; }

		public int? DeliveryTypeId { get; set; }

		public string RecieverAddress { get; set; }

		public int? DeliveryFee { get; set; }
	}
}
