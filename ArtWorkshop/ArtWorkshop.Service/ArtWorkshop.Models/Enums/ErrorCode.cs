namespace ArtWorkshop.Models.Enums
{
	public enum ErrorCode
	{
		UserWithSameEmailAlreadyExists,
		UserNotFound,
		IncorrectPassword,
		UserDataHasNotBeenUpdated,
		PictureTypeDataHasNotBeenUpdated,
		PictyreTypeWithSameNameAlreadyExists,
		CanvasTypeWithSameNameAlreadyExists,
		InvalidPictureTypeId,
		InvalidCanvasTypeId,
		InvalidGildingTypeId,
		InvalidSizeId,
		EmptyName,
		GildingTypeWithSameNameAlreadyExists,
		InvalidCustomerId,
		InvalidDeliveryTypeId,
		InvalidOrderId,
		InvalidAuthorId,
		InvalidPictureId,
		PictureAlreadyBelongsToOtherItem,
		OrderDataHasNotBeenUpdated,
		IncorrectOrderStatus,

		Unauthorized,
		Forbidden,
		InternalServerError
	}
}
