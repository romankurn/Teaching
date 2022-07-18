using ArtWorkshop.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ArtWorkshop.Models.Responses.CanvasType.GetCanvasTypesResponse;

namespace ArtWorkshop.TGBot.Stogare
{
	public class CanvasTypesStorage
	{
		public Dictionary<int, CanvasType> CanvasTypes { get; private set; }

		public CanvasTypesStorage(IArtWorkshopClient artWorkshopClient)
		{
			SetCanvasTypesAsync(artWorkshopClient).Wait();
		}

		private async Task SetCanvasTypesAsync(IArtWorkshopClient artWorkshopClient)
		{
			var CanvasTypeResponse = await artWorkshopClient.GetCanvasTypes();

			var Position = 1;

			CanvasTypes = CanvasTypeResponse.CanvasTypes.ToDictionary(k => Position++, v => v);
		}
	}
}
