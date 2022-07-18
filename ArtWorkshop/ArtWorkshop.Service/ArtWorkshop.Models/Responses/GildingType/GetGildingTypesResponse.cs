using System.Collections.Generic;

namespace ArtWorkshop.Models.Responses.GildingType
{
	public class GetGildingTypesResponse
	{
		public IEnumerable<GildingType> GildingTypes { get; set; }

		public class GildingType
		{
			public int Id { get; set; }

			public string Name { get; set; }

			public int Position { get; set; }
		}
	}
}
