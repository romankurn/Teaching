using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Models.Picture;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Models.Picture;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Services
{
	public class PictureService : IPictureService
	{
		readonly private IPictureRepository _pictureRepository;

		public PictureService(IPictureRepository pictureRepository)
		{
			_pictureRepository = pictureRepository;
		}

		public async Task<int> CreatePictureAsync(PictureModel model)
		{
			return (await _pictureRepository.CreatePictureAsync(new PictureCreateDalModel
			{
				Name = model.Name,
				SizeId = model.SizeId,
				CanvasTypeId = model.CanvasTypeId,
				GildingTypeId = model.GildingTypeId,
				PictureTypeId = model.PictureTypeId,
			})).Value;
		}
	}
}
