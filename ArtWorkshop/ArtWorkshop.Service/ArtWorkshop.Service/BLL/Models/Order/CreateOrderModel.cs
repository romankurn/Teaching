namespace ArtWorkshop.Service.BLL.Models.Order
{
	public class CreateOrderModel
	{
		public int CustomerId { get; set; }

		public int DeliveryTypeId { get; set; }

		public string RecieverAddress { get; set; }

		public int DeliveryFee { get; set; }
	}
}
