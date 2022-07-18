using ArtWorkshop.Service.DAL.Models.User;
using ArtWorkshop.Service.DataBaseLayer.Models.User;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DataBaseLayer.Interfaces
{
	public interface IUserRepository
	{
		Task<User> GetUserByIdAsync(int userId);

		Task SignUpUserAsync(UserSignUpDalModel dal);

		Task<bool> CheckUserEmailAsync(string email);

		Task<int?> CheckUserPasswordAsync(UserSignInDalModel dal);

		Task<int?> ChangeUserDataAsync(UserChangeDataDalModel dal);

		Task<int?> DeleteUserAsync(int userId);
	}
}
