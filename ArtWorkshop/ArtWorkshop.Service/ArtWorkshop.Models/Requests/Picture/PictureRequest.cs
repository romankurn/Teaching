namespace ArtWorkshop.Models.Requests.Picture
{
	public class CreatePictureRequest
	{
		public string Name { get; set; }

		public int SizeId { get; set; }

		public int PictureTypeId { get; set; }

		public int CanvasTypeId { get; set; }

		public int GildingTypeId { get; set; }
	}
}
