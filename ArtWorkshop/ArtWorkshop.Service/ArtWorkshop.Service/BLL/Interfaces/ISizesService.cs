using ArtWorkshop.Service.BLL.Models.Sizes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Interfaces
{
	public interface ISizesService
	{
		Task<IEnumerable<GetSizesModel>> GetSizesAsync();
	}
}
