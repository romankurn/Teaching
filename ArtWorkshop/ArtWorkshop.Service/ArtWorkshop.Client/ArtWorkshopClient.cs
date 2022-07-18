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
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArtWorkshop.Client
{
	public class ArtWorkshopClient : ApiClient, IArtWorkshopClient
	{

		public ArtWorkshopClient(HttpClient httpClient) : base(httpClient)
		{

		}

		#region CanvasType
		public async Task<CreateCanvasTypeResponse> CreateCanvasType(CreateCanvasTypeRequest request, int userId)
		{
			return await PostAsync<CreateCanvasTypeRequest, CreateCanvasTypeResponse>("api/canvas-type/createType", request, userId);
		}

		public async Task<GetCanvasTypesResponse> GetCanvasTypes()
		{
			return await GetAsync<GetCanvasTypesResponse>("api/canvas-type/all");
		}
		#endregion

		#region GildingType
		public async Task<CreateGildingTypeResponse> CreateGildingType(CreateGildingTypeRequest request, int userId)
		{
			return await PostAsync<CreateGildingTypeRequest, CreateGildingTypeResponse>("api/gilding-type/createType", request, userId);
		}

		public async Task<GetGildingTypesResponse> GetGildingTypes()
		{
			return await GetAsync<GetGildingTypesResponse>("api/gilding-type/all");
		}
		#endregion

		#region Item
		public async Task<CreateItemResponse> CreateItem(CreateItemRequest request, int userId)
		{
			return await PostAsync<CreateItemRequest, CreateItemResponse>("api/item/create", request, userId);
		}
		#endregion

		#region Order
		public async Task<CreateOrderResponse> CreateOrder(CreateOrderRequest request, int userId)
		{
			return await PostAsync<CreateOrderRequest, CreateOrderResponse>("api/order/create", request, userId);
		}

		public async Task<GetOrdersResponse> GetOrdersByUserId(int customerId, int userId)
		{
			var parameters = new Dictionary<string, string>
			{
				{nameof(customerId), customerId.ToString() }
			};

			return await GetAsync<GetOrdersResponse>("api/order/byUserId", parameters, userId: userId);
		}

		public async Task<GetOrdersResponse> GetOrdersByStatus(string status, int userId)
		{
			var parameters = new Dictionary<string, string>
			{
				{nameof(status), status }
			};

			return await GetAsync<GetOrdersResponse>("api/order/byOrderStatus", parameters, userId: userId);
		}

		public async Task<ChangeOrderDataResponse> ChangeOrderData(ChangeOrderDataRequest request, int userId)
		{
			return await PostAsync<ChangeOrderDataRequest, ChangeOrderDataResponse>("api/order/change", request, userId);
		}
		#endregion

		#region Picture
		public async Task<CreatePictureResponse> CreatePicture(CreatePictureRequest request, int userId)
		{
			return await PostAsync<CreatePictureRequest, CreatePictureResponse>("api/picture/create", request, userId);
		}
		#endregion

		#region PictureType
		public async Task<CreatePictureTypeResponse> CreatePictureType(PictureTypeCreateRequest request, int userId)
		{
			return await PostAsync<PictureTypeCreateRequest, CreatePictureTypeResponse>("api/picture-type/createType", request, userId);
		}

		public async Task<ChangePictureTypeDataResponse> ChangePictureTypeData(ChangePictureTypeDataRequest request, int userId)
		{
			return await PostAsync<ChangePictureTypeDataRequest, ChangePictureTypeDataResponse>("api/picture-type/changeData", request, userId);
		}

		public async Task<GetPictureTypesResponse> GetPictureTypes()
		{
			return await GetAsync<GetPictureTypesResponse>("api/picture-type/all");
		}
		#endregion

		#region Sizes
		public async Task<GetSizesResponse> GetSizes()
		{
			return await GetAsync<GetSizesResponse>("api/sizes/all");
		}
		#endregion

		#region Users
		public async Task<UserSignUpResponse> SignUp(UserSignUpRequest request)
		{
			return await PostAsync<UserSignUpRequest, UserSignUpResponse>("api/user/signUp", request);
		}

		public async Task<UserSignInResponse> SignIn(UserSignInRequest request)
		{
			return await PostAsync<UserSignInRequest, UserSignInResponse>("api/user/signIn", request);
		}

		public async Task<UserLogOutResponse> SignOut(int userId)
		{
			return await GetAsync<UserLogOutResponse>("api/user/logOut", userId: userId);
		}

		public async Task<UserChangeDataResponse> ChangeData(UserChangeDataRequest request, int userId)
		{
			return await PostAsync<UserChangeDataRequest, UserChangeDataResponse>("api/user/changeData", request, userId);
		}

		public async Task<UserDeleteResponse> Delete(int deletedUserId, int userId)
		{
			return await DeleteAsync<UserDeleteResponse>("api/user/byId", userId: userId);
		}
		#endregion
	}
}
