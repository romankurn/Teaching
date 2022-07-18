using ArtWorkshop.Service.BLL.Models.Picture;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Interfaces
{
	public interface IPictureService
	{
		Task<int> CreatePictureAsync(PictureModel model);
	}
}
