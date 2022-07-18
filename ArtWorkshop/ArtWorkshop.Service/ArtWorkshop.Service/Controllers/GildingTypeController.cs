using ArtWorkshop.Models.Enums;
using ArtWorkshop.Models.Requests.GildingType;
using ArtWorkshop.Models.Responses.GildingType;
using ArtWorkshop.Service.Autorization;
using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.Exceptions.GildingType;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.Controllers
{
	[Route("api/gilding-type")]
	public class GildingTypeController : Controller
	{
		private readonly IGildingTypeService _gildingTypeService;

		public GildingTypeController(IGildingTypeService gildingTypeService)
		{
			_gildingTypeService = gildingTypeService;
		}

		[HttpPost("createType")]
		[CustomAuthorize(Roles.Admin)]
		public async Task<ActionResult<CreateGildingTypeResponse>> GildingTypeType([FromBody] CreateGildingTypeRequest request)
		{
			try
			{
				await _gildingTypeService.CreateGildingTypeAsync(request.Name);

				return Ok(new CreateGildingTypeResponse());
			}
			catch (GildingTypeWithSameNameAlreadyExistsException ex)
			{
				return BadRequest(ErrorCode.GildingTypeWithSameNameAlreadyExists.ToString());
			}
		}

		[HttpGet("all")]		
		public async Task<ActionResult<GetGildingTypesResponse>> GetGildingTypes()
		{
			var result = await _gildingTypeService.GetGildingTypesAsync();

			return Ok(new GetGildingTypesResponse
			{
				GildingTypes = result.Select(r => new GetGildingTypesResponse.GildingType
				{
					Id = r.Id,
					Name = r.Name,
					Position = r.Position
				})
			});
		}
	}
}
