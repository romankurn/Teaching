using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

namespace ArtWorkshop.Models.Responses.PictureType
{
	public class GetPictureTypesResponse
	{
		public IEnumerable<PictureType> PictureTypes { get; set; }

		public class PictureType
		{
			public int Id { get; set; }

			public string Name { get; set; }

			public byte[] File {get; set; }

		}
	}
}
