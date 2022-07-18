using ArtWorkshop.Service.BLL.Helpers;
using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Models.PictureType;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Models.PictureType;
using ArtWorkshop.Service.Exceptions.PictureType;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BLL.Services
{
	public class PictureTypeService : IPictureTypeService
	{
		private readonly IPictureTypeRepository _pictureTypeRepository;
		private readonly FileReader _fileReader;

		public PictureTypeService(IPictureTypeRepository pictureTypeRepository, FileReader fileReader)
		{
			_pictureTypeRepository = pictureTypeRepository;

			_fileReader = fileReader;
		}


		public async Task<IEnumerable<GetPictureTypesModel>> GetPictureTypesAsync()
		{
			var pictureTypes = await _pictureTypeRepository.GetPictureTypesAsync();

			var result = new ConcurrentQueue<GetPictureTypesModel>();

			Parallel.ForEach(pictureTypes, async pictureType =>
			{
				var bytes = await _fileReader.ReadFileAsync(pictureType.Template);

				result.Enqueue(new GetPictureTypesModel
				{
					Id = pictureType.Id,
					Name = pictureType.Name,
					FileName = Path.GetFileName(pictureType.Template),
					File = bytes
				});
			});

			return result;
		}

		public async Task CreatePictureTypeAsync(PictureTypeCreateModel model)
		{
			await _pictureTypeRepository.CreatePictureTypeAsync(new PictureTypeCreateDalModel
			{
				Name = model.Name,
				PicturePath = model.PicturePath
			});
		}

		public async Task ChangePictureTypeDataAsync(PictureTypeCangeDataModel model)
		{
			var updatedRowCount = await _pictureTypeRepository.ChangePictureTypeDataAsync(new PictureTypeChangeDataDalModel
			{
				Id = model.Id,
				Name = model.Name,
				PicturePath = model.PicturePath
			});

			if (!updatedRowCount.HasValue)
				throw new PictureTypeDataHasNotBeenUpdatedException();
		}
	}
}
