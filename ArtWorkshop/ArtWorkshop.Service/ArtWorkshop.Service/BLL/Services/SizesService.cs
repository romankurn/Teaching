using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Models.Sizes;
using ArtWorkshop.Service.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Services
{
	public class SizesService : ISizesService
	{
		private readonly ISizesRepository _sizesRepository;

		public SizesService(ISizesRepository sizesRepository)
		{
			_sizesRepository = sizesRepository;
		}

		public async Task<IEnumerable<GetSizesModel>> GetSizesAsync()
		{
			var sizes = await _sizesRepository.GetSizesAsync();

			return sizes.Select(s => new GetSizesModel { Id = s.Id, Size = s.Size, Position = s.Position });
		}
	}
}
