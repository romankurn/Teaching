using ArtWorkshop.Service.DAL.Models.GildingType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Interfaces
{
	public interface IGildingTypeRepository
	{
		Task CreateGildingTypeAsync(string name);

		Task<IEnumerable<GildingType>> GetGildingTypesAsync();

		//Task<int?> ChangeGildingTypeAsync(string name);
	}
}
