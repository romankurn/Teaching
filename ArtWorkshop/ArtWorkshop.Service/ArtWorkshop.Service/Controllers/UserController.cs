using ArtWorkshop.Models.Enums;
using ArtWorkshop.Models.Requests.User;
using ArtWorkshop.Models.Responses.User;
using ArtWorkshop.Service.Autorization;
using ArtWorkshop.Service.BusinessLogicLayer.Interfaces;
using ArtWorkshop.Service.BusinessLogicLayer.Models.User;
using ArtWorkshop.Service.Exceptions.User;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.Controllers
{
	[Route("api/user")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}


		[HttpPost("signUp")]
		public async Task<ActionResult<UserSignUpResponse>> SignUp([FromBody] UserSignUpRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var userSignUpModel = new UserSignUpModel
				{
					Email = request.Email,
					FirstName = request.FirstName,
					Password = request.Password,
					SecondName = request.SecondName
				};

				await _userService.SignUpUserAsync(userSignUpModel);

				return Ok(new UserSignUpResponse());
			}
			catch (UserWithSameEmailAlreadyExistsException ex)
			{

				return BadRequest(ErrorCode.UserWithSameEmailAlreadyExists.ToString());
			}
		}

		[HttpPost("signIn")]
		public async Task<ActionResult<UserSignInResponse>> SignIn([FromBody] UserSignInRequest request)
		{
			try
			{
				var result = await _userService.SignInUserAsync(new UserSignInModel
				{
					Email = request.Email,
					Password = request.Password
				});

				Autorize(result.Id, result.Role);

				return Ok(new UserSignInResponse { Role = result.Role, Id = result.Id });
			}
			catch (UserNotFoundException ex)
			{
				return BadRequest(ErrorCode.UserNotFound.ToString());
			}
			catch (IncorrectPasswordException ex)
			{
				return BadRequest(ErrorCode.IncorrectPassword.ToString());
			}
		}

		[HttpGet("logOut")]
		[CustomAuthorize]
		public ActionResult<UserLogOutResponse> LogOut()
		{
			try
			{
				if (HttpContext.Request.Headers.TryGetValue("userId", out var value))
				{
					var userId = int.Parse(value.First());

					LogOut(userId);

					return Ok(new UserLogOutResponse());
				}
				else
				{
					return new UnauthorizedResult();
				}
			}
			catch (UserNotFoundException ex)
			{
				return BadRequest(ErrorCode.UserNotFound.ToString());
			}
		}

		[HttpPost("changeData")]
		[CustomAuthorize("Admin", "Customer", "Worker")]
		public async Task<ActionResult<UserChangeDataResponse>> ChangeData([FromBody] UserChangeDataRequest request)
		{
			try
			{
				await _userService.ChangeUserDataAsync(new UserChangeDataModel
				{
					Id = request.Id,
					FirstName = request.FirstName,
					SecondName = request.SecondName
				});

				return Ok(new UserChangeDataResponse());
			}
			catch (UserDataHasNotBeenUpdatedException ex)
			{
				return BadRequest(ErrorCode.UserDataHasNotBeenUpdated.ToString());
			}
		}

		[HttpDelete("byId")]
		[CustomAuthorize(Roles.Admin)]
		public async Task<ActionResult<UserDeleteResponse>> Delete([FromQuery] int deletedUserId)
		{
			try
			{
				await _userService.DeleteUserAsync(deletedUserId);

				return Ok(new UserDeleteResponse());
			}
			catch (UserNotFoundException ex)
			{
				return BadRequest(ErrorCode.UserNotFound.ToString());
			}
		}
	}


}
