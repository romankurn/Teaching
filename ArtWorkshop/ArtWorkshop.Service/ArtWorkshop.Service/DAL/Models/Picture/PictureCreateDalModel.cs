using ArtWorkshop.Models.Enums;

namespace ArtWorkshop.Service.DAL.Models.Picture
{
	public class PictureCreateDalModel
	{
		public string Name { get; set; }

		public int SizeId { get; set; }

		public int PictureTypeId { get; set; }

		public int CanvasTypeId { get; set; }

		public int GildingTypeId { get; set; }
	}
}
