namespace ArtWorkshop.Service.BLL.Models.Order
{
	public class OrderModel
	{
		public int Id { get; set; }

		public int CustomerId { get; set; }

		public string Status { get; set; }

		public int? DeliveryTypeId { get; set; }

		public string RecieverAddress { get; set; }

		public int? DeliveryFee { get; set; }
	}
}
