using ArtWorkshop.Service.BLL.Models.GildingType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Interfaces
{
	public interface IGildingTypeService
	{
		Task CreateGildingTypeAsync(string name);

		Task<IEnumerable<GetGildingTypeModel>> GetGildingTypesAsync();

		//Task ChangeGildingTypeAsync(string name);
	}
}
