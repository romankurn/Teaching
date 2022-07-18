using ArtWorkshop.Models.Requests.CanvasType;
using ArtWorkshop.Models.Requests.GildingType;
using ArtWorkshop.Models.Requests.Item;
using ArtWorkshop.Models.Requests.Order;
using ArtWorkshop.Models.Requests.Picture;
using ArtWorkshop.Models.Requests.PictureType;
using ArtWorkshop.Models.Requests.User;
using ArtWorkshop.Models.Responses.CanvasType;
using ArtWorkshop.Models.Responses.GildingType;
using ArtWorkshop.Models.Responses.Item;
using ArtWorkshop.Models.Responses.Order;
using ArtWorkshop.Models.Responses.Picture;
using ArtWorkshop.Models.Responses.PictureType;
using ArtWorkshop.Models.Responses.Sizes;
using ArtWorkshop.Models.Responses.User;
using System;
using System.Threading.Tasks;

namespace ArtWorkshop.Client
{
	public interface IArtWorkshopClient
	{
		#region CanvasType
		Task<CreateCanvasTypeResponse> CreateCanvasType(CreateCanvasTypeRequest request, int userId);
		Task<GetCanvasTypesResponse> GetCanvasTypes();
		#endregion

		#region GildingType
		Task<CreateGildingTypeResponse> CreateGildingType(CreateGildingTypeRequest request, int userId);
		Task<GetGildingTypesResponse> GetGildingTypes();
		#endregion

		#region Item
		Task<CreateItemResponse> CreateItem(CreateItemRequest request, int userId);
		#endregion

		#region Order
		Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request, int userId);
		Task<GetOrdersResponse> GetOrdersByUserId(int customerId, int userId);
		Task<GetOrdersResponse> GetOrdersByStatus(string status, int userId);
		Task<ChangeOrderDataResponse> ChangeOrderData(ChangeOrderDataRequest request, int userId);
		#endregion

		#region Picture
		Task<CreatePictureResponse> CreatePicture(CreatePictureRequest request, int userId);
		#endregion

		#region PictureType
		Task<CreatePictureTypeResponse> CreatePictureType(PictureTypeCreateRequest request, int userId);
		Task<ChangePictureTypeDataResponse> ChangePictureTypeData(ChangePictureTypeDataRequest request, int userId);
		Task<GetPictureTypesResponse> GetPictureTypes();
		#endregion

		#region Sizes
		Task<GetSizesResponse> GetSizes();
		#endregion

		#region Users
		Task<UserSignUpResponse> SignUp(UserSignUpRequest request);
		Task<UserSignInResponse> SignIn(UserSignInRequest request);
		Task<UserLogOutResponse> SignOut(int userId);
		Task<UserChangeDataResponse> ChangeData(UserChangeDataRequest request, int userId);
		Task<UserDeleteResponse> Delete(int deletedUserId, int userId);
		#endregion
	}
}
