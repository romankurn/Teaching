using System;

namespace ArtWorkshop.Service.DAL.Models.Item
{
	public class ItemDalModel
	{
		public int Id { get; set; }

		public int OrderId { get; set; }

		public int CustomerId { get; set; }

		public int AuthorId { get; set; }

		public int PictureId { get; set; }

		public int Price { get; set; }

		public string Status { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime FinishDate { get; set; }
	}
}
