using ArtWorkshop.Models.Enums;
using ArtWorkshop.Models.Requests.Picture;
using ArtWorkshop.Models.Responses.Picture;
using ArtWorkshop.Service.Autorization;
using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Models.Picture;
using ArtWorkshop.Service.Exceptions.Picture;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.Controllers
{
	[Route("api/picture")]
	public class PictureController : Controller
	{
		private readonly IPictureService _pictureService;

		public PictureController(IPictureService pictureService)
		{
			_pictureService = pictureService;
		}

		[HttpPost("create")]
		[CustomAuthorize(Roles.Admin, Roles.Customer)]
		public async Task<ActionResult<CreatePictureResponse>> CreatePicture([FromBody] CreatePictureRequest request)
		{
			try
			{
				var pictureId = await _pictureService.CreatePictureAsync(new PictureModel
				{
					Name = request.Name,
					CanvasTypeId = request.CanvasTypeId,
					GildingTypeId = request.GildingTypeId,
					PictureTypeId = request.PictureTypeId,
					SizeId = request.SizeId
				});

				return Ok(new CreatePictureResponse { PictureId = pictureId});
			}
			catch(InvalidPictureTypeIdException ex)
			{
				return BadRequest(ErrorCode.InvalidPictureTypeId.ToString());
			}
			catch(InvalidCanvasTypeIdException ex)
			{
				return BadRequest(ErrorCode.InvalidCanvasTypeId.ToString());
			}
			catch(InvalidGildingTypeIdException ex)
			{
				return BadRequest(ErrorCode.InvalidGildingTypeId.ToString());
			}
			catch(InvalidSizeIdException ex)
			{
				return BadRequest(ErrorCode.InvalidSizeId.ToString());
			}
			catch(EmptyNameException ex)
			{
				return BadRequest(ErrorCode.EmptyName.ToString());
			}
		}
	}
}
