using ArtWorkshop.Service.DAL.Models.Picture;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Interfaces
{
	public interface IPictureRepository
	{
		Task<int?> CreatePictureAsync(PictureCreateDalModel dal);
	}
}
