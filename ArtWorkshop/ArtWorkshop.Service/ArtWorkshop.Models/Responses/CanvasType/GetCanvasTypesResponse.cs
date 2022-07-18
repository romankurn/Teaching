using System.Collections.Generic;

namespace ArtWorkshop.Models.Responses.CanvasType
{
	public class GetCanvasTypesResponse
	{
		public IEnumerable<CanvasType> CanvasTypes { get; set; }

		public class CanvasType
		{
			public int Id { get; set; }

			public string Name { get; set; }
		}
	}
}
