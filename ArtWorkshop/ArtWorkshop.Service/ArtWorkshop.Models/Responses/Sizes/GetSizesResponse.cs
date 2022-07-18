using System.Collections.Generic;

namespace ArtWorkshop.Models.Responses.Sizes
{
	public class GetSizesResponse
	{
		public IEnumerable<SizesModel> Sizes { get; set; }

		public class SizesModel
		{
			public int Id { get; set; }

			public string Size { get; set; }

			public int Position { get; set; }
		}
	}
}
