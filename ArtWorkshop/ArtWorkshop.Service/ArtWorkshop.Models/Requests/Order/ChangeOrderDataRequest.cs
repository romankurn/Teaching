namespace ArtWorkshop.Models.Requests.Order
{
	public class ChangeOrderDataRequest
	{
		public int Id {	get; set;}		 

		public string Status { get; set; }

		public int? DeliveryTypeId { get; set; }

		public string RecieverAddress { get; set; }

		public int? DeliveryFee { get; set; }
	}
}
