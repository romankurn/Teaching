using ArtWorkshop.Service.BLL.Models.CanvasType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Interfaces
{
	public interface ICanvasTypeService
	{
		Task CreateCanvasTypeAsync(string name);

		Task<IEnumerable<GetCanvasTypesModel>> GetCanvasTypesAsync();

		//Task ChangeCanvasTypeAsync(string name);
	}
}
