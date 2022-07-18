using ArtWorkshop.Service.DAL.Models.PictureType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Interfaces
{
	public interface IPictureTypeRepository
	{
		Task<IEnumerable<PictureType>> GetPictureTypesAsync();

		Task CreatePictureTypeAsync(PictureTypeCreateDalModel dal);

		Task<int?> ChangePictureTypeDataAsync(PictureTypeChangeDataDalModel dal);
	}
}
