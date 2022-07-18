using ArtWorkshop.Models.Enums;
using ArtWorkshop.Models.Requests.CanvasType;
using ArtWorkshop.Models.Responses.CanvasType;
using ArtWorkshop.Service.Autorization;
using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.Exceptions.CanvasType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.Controllers
{
	[Route("api/canvas-type")]
	public class CanvasTypeController : Controller
	{
		private readonly ICanvasTypeService _canvasTypeService;

		public CanvasTypeController(ICanvasTypeService canvasTypeService)
		{
			_canvasTypeService = canvasTypeService;
		}

		[HttpPost("createType")]
		[CustomAuthorize(Roles.Admin)]
		public async Task<ActionResult<CreateCanvasTypeResponse>> CreateCanvasType([FromBody] CreateCanvasTypeRequest request)
		{
			try
			{
				await _canvasTypeService.CreateCanvasTypeAsync(request.Name);

				return Ok(new CreateCanvasTypeResponse());
			}
			catch (CanvasTypeWithSameNameAlreadyExistsException ex)
			{
				return BadRequest(ErrorCode.CanvasTypeWithSameNameAlreadyExists.ToString());
			}
		}

		[HttpGet("all")]		
		public async Task<ActionResult<GetCanvasTypesResponse>> GetCanvasTypes()
		{
			var result = await _canvasTypeService.GetCanvasTypesAsync();

			return Ok(new GetCanvasTypesResponse
			{
				CanvasTypes = result.Select(r => new GetCanvasTypesResponse.CanvasType
				{
					Id = r.Id,
					Name = r.Name
				})
			});
		}
	}
}
