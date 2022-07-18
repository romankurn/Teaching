using ArtWorkshop.Service.DAL.Models.CanvasType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Interfaces
{
	public interface ICanvasTypeRepository
	{
		Task CreateCanvasTypeAsync(string name);

		Task<IEnumerable<CanvasType>> GetCanvasTypesAsync();

		//Task<int?> ChangeCanvasTypeAsync(string name);
	}
}
