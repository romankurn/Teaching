using ArtWorkshop.Models.Enums;
using ArtWorkshop.Models.Requests.PictureType;
using ArtWorkshop.Models.Responses.PictureType;
using ArtWorkshop.Service.Autorization;
using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Models.PictureType;
using ArtWorkshop.Service.Exceptions.PictureType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.Controllers
{
	[Route("api/picture-type")]
	public class PictureTypeController : Controller
	{
		private readonly IPictureTypeService _pictureTypeService;

		public PictureTypeController(IPictureTypeService pictureTypeService)
		{
			_pictureTypeService = pictureTypeService;
		}

		[HttpPost("createType")]
		[CustomAuthorize(Roles.Admin)]
		public async Task<ActionResult<CreatePictureTypeResponse>> CreatePictureType([FromBody] PictureTypeCreateRequest request)
		{
			try
			{
				var createPictureTypeModel = new PictureTypeCreateModel
				{
					Name = request.Name,
					PicturePath = request.PicturePath
				};

				await _pictureTypeService.CreatePictureTypeAsync(createPictureTypeModel);

				return Ok(new CreatePictureTypeResponse());
			}
			catch(PictyreTypeWithSameNameAlreadyExistsException ex)
			{
				return BadRequest(ErrorCode.PictyreTypeWithSameNameAlreadyExists.ToString());
			}
		}

		[HttpPost("changeData")]
		[CustomAuthorize(Roles.Admin)]
		public async Task<ActionResult<ChangePictureTypeDataResponse>> ChangePictureTypeDataAsync([FromBody] ChangePictureTypeDataRequest request)
		{
			try
			{
				await _pictureTypeService.ChangePictureTypeDataAsync(new PictureTypeCangeDataModel
				{
					Id = request.Id,
					Name = request.Name,
					PicturePath = request.PicturePath
				});

				return Ok(new ChangePictureTypeDataResponse());
			}				
			catch (PictureTypeDataHasNotBeenUpdatedException ex)
			{
				return BadRequest(ErrorCode.PictureTypeDataHasNotBeenUpdated.ToString());
			}
			catch (PictyreTypeWithSameNameAlreadyExistsException ex)
			{
				return BadRequest(ErrorCode.PictyreTypeWithSameNameAlreadyExists.ToString());
			}
		}

		[HttpGet("all")]		
        public async Task<ActionResult<GetPictureTypesResponse>> GetPictureTypes()
		{
			var result = await _pictureTypeService.GetPictureTypesAsync();

			return Ok(new GetPictureTypesResponse
			{
				PictureTypes = result.Select(r => new GetPictureTypesResponse.PictureType
				{
					Id = r.Id,
					Name = r.Name,
					File = r.File
				})
			});
		}

	}
}
