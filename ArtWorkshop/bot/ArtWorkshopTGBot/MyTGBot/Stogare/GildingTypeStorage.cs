using ArtWorkshop.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ArtWorkshop.Models.Responses.GildingType.GetGildingTypesResponse;

namespace ArtWorkshop.TGBot.Stogare
{
	public class GildingTypeStorage
	{
		public Dictionary<int, GildingType> GildingTypes { get; private set; }

		public GildingTypeStorage(IArtWorkshopClient artWorkshopClient)
		{
			SetGildingTypesAsync(artWorkshopClient).Wait();
		}

		private async Task SetGildingTypesAsync(IArtWorkshopClient artWorkshopClient)
		{
			var GildingTypeResponse = await artWorkshopClient.GetGildingTypes();

			var Position = 1;

			GildingTypes = GildingTypeResponse.GildingTypes.ToDictionary(k => Position++, v => v);
		}
	}
}
