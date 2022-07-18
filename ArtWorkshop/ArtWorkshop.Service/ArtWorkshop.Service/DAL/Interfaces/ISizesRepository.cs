using ArtWorkshop.Service.DAL.Models.Sizes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Interfaces
{
	public interface ISizesRepository
	{
		Task<IEnumerable<SizesDalModel>> GetSizesAsync();
	}
}
