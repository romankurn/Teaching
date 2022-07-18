namespace ArtWorkshop.Models.Requests.Order
{
	public class CreateOrderRequest
	{
		public int CustomerId { get; set; }

		public string RecieverAddress { get; set; }
	}
}
