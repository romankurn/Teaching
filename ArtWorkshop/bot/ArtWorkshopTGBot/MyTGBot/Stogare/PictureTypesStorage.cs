using ArtWorkshop.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ArtWorkshop.Models.Responses.PictureType.GetPictureTypesResponse;

namespace ArtWorkshop.TGBot.Stogare
{
	public class PictureTypesStorage
	{
		public Dictionary<int, PictureType> PictureTypes { get; private set; }

		public PictureTypesStorage(IArtWorkshopClient artWorkshopClient)
		{
			SetPictureTypesAsync(artWorkshopClient).Wait();
		}

		private async Task SetPictureTypesAsync(IArtWorkshopClient artWorkshopClient)
		{
			var pictureTypeResponse = await artWorkshopClient.GetPictureTypes();

			var Position = 1;

			PictureTypes = pictureTypeResponse.PictureTypes.ToDictionary(k => Position++, v => v);
		}
	}
}
