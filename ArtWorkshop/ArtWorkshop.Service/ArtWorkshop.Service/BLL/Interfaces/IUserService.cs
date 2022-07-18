using ArtWorkshop.Service.BLL.Models.User;
using ArtWorkshop.Service.BusinessLogicLayer.Models.User;
using ArtWorkshop.Service.DataBaseLayer.Models.User;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.BusinessLogicLayer.Interfaces
{
	public interface IUserService
	{ 

		Task SignUpUserAsync(UserSignUpModel model);

		Task<UserSignInResponseModel> SignInUserAsync(UserSignInModel model);

		Task ChangeUserDataAsync(UserChangeDataModel model);

		Task DeleteUserAsync(int userId);
	}
}
