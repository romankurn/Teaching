using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Models.GildingType;
using ArtWorkshop.Service.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Services
{
	public class GildingTypeService : IGildingTypeService
	{
		private readonly IGildingTypeRepository _gildingTypeRepository;

		public GildingTypeService(IGildingTypeRepository gildingTypeRepository)
		{
			_gildingTypeRepository = gildingTypeRepository;
		}

		public async Task CreateGildingTypeAsync(string name)
		{
			await _gildingTypeRepository.CreateGildingTypeAsync(name);
		}

		public async Task<IEnumerable<GetGildingTypeModel>> GetGildingTypesAsync()
		{
			var gildingTypes = await _gildingTypeRepository.GetGildingTypesAsync();

			return gildingTypes.Select(g => new GetGildingTypeModel { Id = g.Id, Name = g.Name, Position = g.Position });
		}
	}
}
