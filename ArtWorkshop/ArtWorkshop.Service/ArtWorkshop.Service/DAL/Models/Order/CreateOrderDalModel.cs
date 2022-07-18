namespace ArtWorkshop.Service.DAL.Models.Order
{
	public class CreateOrderDalModel
	{
		public int CustomerId { get; set; }

		public string Status { get; set; }

		public int DeliveryTypeId { get; set; }

		public string RecieverAddress { get; set; }

		public int DeliveryFee { get; set; }
	}
}
