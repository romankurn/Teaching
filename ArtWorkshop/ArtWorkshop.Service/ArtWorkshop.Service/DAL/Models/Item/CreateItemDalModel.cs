using System;

namespace ArtWorkshop.Service.DAL.Models.Item
{
	public class CreateItemDalModel
	{
		public int OrderId { get; set; }
		
		public int PictureId { get; set; }		

		public string Status { get; set; }

		public DateTime StartDate { get; set; }		
	}
}
