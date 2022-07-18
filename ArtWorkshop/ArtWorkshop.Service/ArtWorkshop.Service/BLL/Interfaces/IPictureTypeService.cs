using ArtWorkshop.Service.BLL.Models.PictureType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Interfaces
{
	public interface IPictureTypeService
	{
		Task<IEnumerable<GetPictureTypesModel>> GetPictureTypesAsync();

		Task CreatePictureTypeAsync(PictureTypeCreateModel model);

		Task ChangePictureTypeDataAsync(PictureTypeCangeDataModel model);
	}
}
