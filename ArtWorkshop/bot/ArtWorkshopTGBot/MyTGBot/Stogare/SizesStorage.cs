using ArtWorkshop.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ArtWorkshop.Models.Responses.Sizes.GetSizesResponse;

namespace ArtWorkshop.TGBot.Stogare
{
	public class SizesStorage
	{
		public Dictionary<int, SizesModel> Sizes { get; private set; }

		public SizesStorage(IArtWorkshopClient artWorkshopClient)
		{
			SetSizesAsync(artWorkshopClient).Wait();
		}

		private async Task SetSizesAsync(IArtWorkshopClient artWorkshopClient)
		{
			var sizeResponse = await artWorkshopClient.GetSizes();

			Sizes = sizeResponse.Sizes.ToDictionary(k => k.Position, v => v);
		}
	}
}
