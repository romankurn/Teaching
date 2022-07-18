using ArtWorkshop.Models.Responses.Sizes;
using ArtWorkshop.Service.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.Controllers
{
	[Route("api/sizes")]
	public class SizesController : Controller
	{
		private readonly ISizesService _sizesService;

		public SizesController(ISizesService sizesService)
		{
			_sizesService = sizesService;
		}

		[HttpGet("all")]
		public async Task<ActionResult<GetSizesResponse>> GetSizes()
		{
			var result = await _sizesService.GetSizesAsync();

			return Ok(new GetSizesResponse
			{
				Sizes = result.Select(r => new GetSizesResponse.SizesModel
				{
					Id = r.Id,
					Size = r.Size,
					Position = r.Position
				})
			});
		}
	}
}
