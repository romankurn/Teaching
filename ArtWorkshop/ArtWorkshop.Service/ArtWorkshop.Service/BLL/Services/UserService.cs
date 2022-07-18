using ArtWorkshop.Service.BLL.Enums;
using ArtWorkshop.Service.BLL.Models.User;
using ArtWorkshop.Service.BusinessLogicLayer.Helpers;
using ArtWorkshop.Service.BusinessLogicLayer.Interfaces;
using ArtWorkshop.Service.BusinessLogicLayer.Models.User;
using ArtWorkshop.Service.DAL.Models.User;
using ArtWorkshop.Service.DataBaseLayer.Interfaces;
using ArtWorkshop.Service.DataBaseLayer.Models.User;
using ArtWorkshop.Service.Exceptions.User;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BusinessLogicLayer.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IRoleRepository _roleRepository;
		private readonly ILogger _logger;

		public UserService(
			IUserRepository userRepository,
			IRoleRepository roleRepository,
			ILogger<UserService> logger)
		{
			_userRepository = userRepository;
			_roleRepository = roleRepository;

			_logger = logger;
		}

		public async Task SignUpUserAsync(UserSignUpModel model)
		{
			var passwordHash = PasswordHash.GetHash(model.Password);

			var dalModel = new UserSignUpDalModel
			{
				Email = model.Email,
				Password = passwordHash,
				FirstName = model.FirstName,
				SecondName = model.SecondName,
				Role = Role.Customer.ToString()
			};

			await _userRepository.SignUpUserAsync(dalModel);
		}

		public async Task<UserSignInResponseModel> SignInUserAsync(UserSignInModel model)
		{
			var userExists = await _userRepository.CheckUserEmailAsync(model.Email);

			if (!userExists)
			{
				_logger.LogWarning($"User with provided email '{model.Email}' does not exist.");
				throw new UserNotFoundException();
			}

			var passwordHash = PasswordHash.GetHash(model.Password);

			var userId = await _userRepository.CheckUserPasswordAsync(new UserSignInDalModel
			{
				Password = passwordHash,
				Email = model.Email
			});

			if (!userId.HasValue)
				throw new IncorrectPasswordException();

			var role = await _roleRepository.GetRoleByUserIdAsync(userId.Value);

			return new UserSignInResponseModel
			{
				Id = userId.Value,
				Role = role
			};
		}

		public async Task ChangeUserDataAsync(UserChangeDataModel model)
		{
			var updatedRowCount = await _userRepository.ChangeUserDataAsync(new UserChangeDataDalModel
			{
				Id = model.Id,
				FirstName = model.FirstName,
				SecondName = model.SecondName
			});

			if (!updatedRowCount.HasValue)
				throw new UserDataHasNotBeenUpdatedException();
		}

		public async Task DeleteUserAsync(int userId)
		{
			var deletedRowCount = await _userRepository.DeleteUserAsync(userId);

			if (!deletedRowCount.HasValue)
				throw new UserNotFoundException();
		}
	}
}
