namespace ArtWorkshop.TGBot.Telegram.Enums
{
	public enum TelegramState
	{
		None,
		Authorization,
		SingIn,
		SingUp,

		Customer_MainMenu,
		#region CreateNewOrder
		Customer_CreateNewOrder_СhooseSize,
		Customer_CreateNewOrder_СhooseCanvasType,
		Customer_CreateNewOrder_СhoosePictureType,
		Customer_CreateNewOrder_СhooseGildingType,
		Customer_CreateNewOrder,
		#endregion

		Admin_MainMenu,
		Admin_ChooseActionWithOrder_Menu,

	}
}
