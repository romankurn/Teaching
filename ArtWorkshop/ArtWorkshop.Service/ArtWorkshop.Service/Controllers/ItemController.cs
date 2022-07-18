using ArtWorkshop.Models.Enums;
using ArtWorkshop.Models.Requests.Item;
using ArtWorkshop.Models.Responses.Item;
using ArtWorkshop.Service.Autorization;
using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Models.Item;
using ArtWorkshop.Service.Exceptions.Item;
using ArtWorkshop.Service.Exceptions.Order;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.Controllers
{
	[Route("api/item")]
	public class ItemController : Controller
	{
		private readonly IItemService _iItemService;

		public ItemController(IItemService iItemService)
		{
			_iItemService = iItemService;
		}

		[HttpPost("create")]
		[CustomAuthorize(Roles.Admin, Roles.Customer)]
		public async Task<ActionResult<CreateItemResponse>> CreateItem([FromBody] CreateItemRequest request)
		{
			try
			{
				await _iItemService.CreateItemAsync(new CreateItemModel
				{
					OrderId = request.OrderId,
					PictureId = request.PictureId
				});

				return Ok(new CreateItemResponse());
			}
			catch (InvalidOrderIdException ex)
			{
				return BadRequest(ErrorCode.InvalidOrderId.ToString());
			}
			catch (InvalidCustomerIdException ex)
			{
				return BadRequest(ErrorCode.InvalidCustomerId.ToString());
			}
			catch (InvalidAuthorIdException ex)
			{
				return BadRequest(ErrorCode.InvalidAuthorId.ToString());
			}
			catch (InvalidPictureIdException ex)
			{
				return BadRequest(ErrorCode.InvalidPictureId.ToString());
			}
			catch (PictureAlreadyBelongsToOtherItemException ex)
			{
				return BadRequest(ErrorCode.PictureAlreadyBelongsToOtherItem.ToString());
			}
		} 

	}
}
