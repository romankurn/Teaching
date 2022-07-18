using Microsoft.AspNetCore.Mvc;

namespace ArtWorkshop.Service.BLL.Models.PictureType
{
	public class GetPictureTypesModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string FileName { get; set; }

		public byte[] File { get; set; }
	}
}
