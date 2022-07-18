using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Models.CanvasType;
using ArtWorkshop.Service.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Services
{
	public class CanvasTypeService : ICanvasTypeService
	{
		private readonly ICanvasTypeRepository _canvasTypeRepository;

		public CanvasTypeService(ICanvasTypeRepository canvasTypeRepository)
		{
			_canvasTypeRepository = canvasTypeRepository;
		}

		public async Task CreateCanvasTypeAsync(string name)
		{
			await _canvasTypeRepository.CreateCanvasTypeAsync(name);
		}

		public async Task<IEnumerable<GetCanvasTypesModel>> GetCanvasTypesAsync()
		{
			var canvasTypes = await _canvasTypeRepository.GetCanvasTypesAsync();

			return canvasTypes.Select(c => new GetCanvasTypesModel { Id = c.Id, Name = c.Name });
		}
	}
}
