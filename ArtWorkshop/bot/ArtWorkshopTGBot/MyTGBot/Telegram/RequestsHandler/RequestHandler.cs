using ArtWorkshop.TGBot.Stogare;
using ArtWorkshop.TGBot.Telegram.Enums;
using ArtWorkshop.TGBot.Telegram.TelegramRequests;
using ArtWorkshop.TGBot.Telegram.TelegramRequests.AdminRequests;
using ArtWorkshop.TGBot.Telegram.TelegramRequests.CustomerRequests.CreateOrder;
using ArtWorkshop.TGBot.Telegram.TelegramRequests.SingIn;
using ArtWorkshop.TGBot.Telegram.TelegramRequests.SingUp;
using ArtWorkshop.TGBot.Telegram.TelegramResponses.Keyboards;
using ArtWorkshop.TGBot.Telegram.TelegramUsers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace ArtWorkshop.TGBot.Telegram.RequestsHandler
{
	public class RequestHeandler
	{
		private readonly IServiceProvider _services;

		public RequestHeandler(IServiceProvider services)
		{
			_services = services;
		}

		public async Task HeandleRequest(TelegramUser currentUser, ITelegramBotClient botClient, string requestMessage, CancellationToken cancellationToken)
		{
			if (requestMessage.Equals("/start") && currentUser.CurrentState != TelegramState.None)
			{
				await botClient.SendTextMessageAsync(currentUser.TelegramId,
								"Работа уже начата.");
				return;
			}

			switch (currentUser.CurrentState)
			{
				case (TelegramState.None):
					{
						if (requestMessage.Equals("/start"))
						{
							await _services.GetRequiredService<StartRequest>().HandleAsync(currentUser, cancellationToken, botClient);

							return;
						}

						await botClient.SendTextMessageAsync(currentUser.TelegramId,
								$"Для начала работы используйте команду: /start");

						return;
					}

				case (TelegramState.Authorization):
					{
						if (requestMessage.Equals("Авторизоваться"))
						{
							await _services.GetRequiredService<SingInRequest>().HandleAsync(currentUser, cancellationToken, botClient);

							return;
						}

						if (requestMessage.Equals("Зарегистрироваться"))
						{
							await _services.GetRequiredService<SingUpRequest>().HandleAsync(currentUser, cancellationToken, botClient);

							return;
						}

						if (requestMessage.Equals("Информация"))
						{
							await _services.GetRequiredService<InfoRequest>().HandleAsync(currentUser, cancellationToken, botClient);

							return;
						}

						await botClient.SendTextMessageAsync(currentUser.TelegramId,
								$"Неизвестная команда.{Environment.NewLine}Для авторизации используйте команду: Авторизоваться{Environment.NewLine}Для регистрации используйте команду: Зарегестрироваться{Environment.NewLine}Для получения справки: Информация");
						return;
					}

				case (TelegramState.SingIn):
					{
						if (requestMessage.Equals("Назад"))
						{
							currentUser.CurrentState = TelegramState.None;

							await _services.GetRequiredService<StartRequest>().HandleAsync(currentUser, cancellationToken, botClient);

							return;
						}

						await _services.GetRequiredService<TrySingInRequest>().HandleAsync(currentUser, cancellationToken, botClient, requestMessage);

						return;
					}

				case (TelegramState.SingUp):
					{
						if (requestMessage.Equals("Назад"))
						{
							currentUser.CurrentState = TelegramState.None;

							await _services.GetRequiredService<StartRequest>().HandleAsync(currentUser, cancellationToken, botClient);

							return;
						}

						await _services.GetRequiredService<TrySingUpRequest>().HandleAsync(currentUser, cancellationToken, botClient, requestMessage);

						return;
					}

				#region CustomerMainMenu
				case (TelegramState.Customer_MainMenu):
					{
						if (requestMessage.Equals("Создать новый заказ"))
						{
							await _services.GetRequiredService<CreateNewOrderRequest>().HandleAsync(currentUser, cancellationToken, botClient, requestMessage);

							return;
						}



						if (requestMessage.Equals("Выйти"))
						{
							await _services.GetRequiredService<SingOutRequest>().HandleAsync(currentUser, cancellationToken, botClient);							

							return;
						}

						await botClient.SendTextMessageAsync(currentUser.TelegramId,
								$"Неизвестная команда.{Environment.NewLine}Выберите действие из предложенного меню");

						return;
					}

					#region CreateNewOrder
				case (TelegramState.Customer_CreateNewOrder_СhooseSize):
					{
						if (requestMessage.Equals("Назад"))
						{
							currentUser.CurrentState = TelegramState.Customer_MainMenu;

							await botClient.SendTextMessageAsync(currentUser.TelegramId,
						"Выберите действие",
						replyMarkup: new CustomerMainMenu().Rkm, cancellationToken: cancellationToken);

							return;
						}

						var receivedNumber = int.TryParse(requestMessage, out var number);

						var sizesStorage = _services.GetRequiredService<SizesStorage>().Sizes;

						if (receivedNumber && sizesStorage.TryGetValue(number, out var size))
						{
							await _services.GetRequiredService<СhooseSizeRequest>().HandleAsync(currentUser, cancellationToken, botClient, size.Id.ToString());

							return;
						}

						await botClient.SendTextMessageAsync(currentUser.TelegramId,
								"Размер указан неверно. Выберите нужный вам размер, из списка выше, и введите его номер или нажмите 'Назад' для возвращения к предыдущему пункту меню.");

						return;
					}
				case (TelegramState.Customer_CreateNewOrder_СhooseCanvasType):
					{
						if (requestMessage.Equals("Назад"))
						{
							await _services.GetRequiredService<CreateNewOrderRequest>().HandleAsync(currentUser, cancellationToken, botClient, null);

							return;
						}

						var receivedNumber = int.TryParse(requestMessage, out var number);

						var canvasTypesStorage = _services.GetRequiredService<CanvasTypesStorage>().CanvasTypes;

						if (receivedNumber && canvasTypesStorage.TryGetValue(number, out var canvasType))
						{
							await _services.GetRequiredService<ChooseCanvasTypeRequest>().HandleAsync(currentUser, cancellationToken, botClient, canvasType.Id.ToString());

							return;
						}

						await botClient.SendTextMessageAsync(currentUser.TelegramId,
								"Тип полотна указан неверно. Выберите нужный вам тип полотна, из списка выше, и введите его номер или нажмите 'Назад' для возвращения к предыдущему пункту меню.");

						return;
					}
				case (TelegramState.Customer_CreateNewOrder_СhoosePictureType):
					{
						if (requestMessage.Equals("Назад"))
						{							
							await _services.GetRequiredService<СhooseSizeRequest>().HandleAsync(currentUser, cancellationToken, botClient, null);

							return;
						}

						var receivedNumber = int.TryParse(requestMessage, out var number);

						var pictureTypesStorage = _services.GetRequiredService<PictureTypesStorage>().PictureTypes;

						if (receivedNumber && pictureTypesStorage.TryGetValue(number, out var pictureType))
						{
							await _services.GetRequiredService<ChoosePictureTypeRequest>().HandleAsync(currentUser, cancellationToken, botClient, pictureType.Id.ToString());

							return;
						}

						await botClient.SendTextMessageAsync(currentUser.TelegramId,
								"Тип изображения указан неверно. Выберите нужный вам тип изображения, из списка выше, и введите его номер или нажмите 'Назад' для возвращения к предыдущему пункту меню.");

						return;
					}
				case (TelegramState.Customer_CreateNewOrder_СhooseGildingType):
					{
						if (requestMessage.Equals("Назад"))
						{
							await _services.GetRequiredService<ChooseCanvasTypeRequest>().HandleAsync(currentUser, cancellationToken, botClient, null);

							return;
						}

						var chosenNumber = int.TryParse(requestMessage, out var number);

						var gildingTypesStorage = _services.GetRequiredService<GildingTypeStorage>().GildingTypes;

						if (chosenNumber && gildingTypesStorage.TryGetValue(number, out var gildingType))
						{
							await _services.GetRequiredService<TryCreateNewOrderRequest>().HandleAsync(currentUser, cancellationToken, botClient, gildingType.Id.ToString());

							return;
						}

						await botClient.SendTextMessageAsync(currentUser.TelegramId,
								"Украшение указано неверно. Выберите нужное вам украшение, из списка выше, и введите его номер или введите 'Назад' для возвращения к предыдущему пункту меню.");

						return;
					}
					#endregion
				#endregion

				#region AdminMenu
				case (TelegramState.Admin_MainMenu):
					{
						if (requestMessage.Equals("Работа с существующими заказами..."))
						{
							await botClient.SendTextMessageAsync(currentUser.TelegramId,
						"Выберите действие:",
						replyMarkup: new AdminChooseActionWithOrderMenu().Rkm, cancellationToken: cancellationToken);

							currentUser.CurrentState = TelegramState.Admin_ChooseActionWithOrder_Menu;

							return;
						}



						if (requestMessage.Equals("Выйти"))
						{
							await _services.GetRequiredService<SingOutRequest>().HandleAsync(currentUser, cancellationToken, botClient);

							return;
						}

						return;
					}

				case (TelegramState.Admin_ChooseActionWithOrder_Menu):
					{
						if (requestMessage.Equals("Назад"))
						{
							await _services.GetRequiredService<DisplayAdminMainMenuRequest>().HandleAsync(currentUser, cancellationToken, botClient);

							return;
						}

						if (requestMessage.Equals("Получить Id неподтверждённых заказов"))
						{
							await _services.GetRequiredService<GetAllInitStatusOrdersRequest>().HandleAsync(currentUser, cancellationToken, botClient, requestMessage);

							return;
						}

						return;
					}
					#endregion
			}

			await botClient.SendTextMessageAsync(currentUser.TelegramId,
							"Неизвестная команда");

			await _services.GetRequiredService<SingOutRequest>().HandleAsync(currentUser, cancellationToken, botClient);
		}
	}
}
