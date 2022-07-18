using ArtWorkshop.Service.Config;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Models.Item;
using ArtWorkshop.Service.DataBaseLayer.Repositories;
using ArtWorkshop.Service.Exceptions.Item;
using ArtWorkshop.Service.Exceptions.Order;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Repositories
{
	public class ItemRepository : RepositoryBase, IItemRepository
	{
		public ItemRepository(DBSetting dbSetting) : base(dbSetting)
		{

		}

		public async Task<int?> AssignAuthorToItem(AssignAuthorToItemDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryFirstOrDefaultAsync<int?>($@"
						update 
							public.{quotes}Item{quotes}
						set 
							author_id = @author_id
						where
							id = @id						
						returning 1",
						new { id = dal.Id, author_id = dal.AuthorId });
			}
		}

		//Сдеать одним методом как в изменении ордера


		public async Task<int?> ChangeItemFinishDate(ChangeItemFinishDateDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryFirstOrDefaultAsync<int?>($@"
						update 
							public.{quotes}Item{quotes}
						set 
							finish_date = @finish_date
						where
							id = @id						
						returning 1",
						new { id = dal.Id, finish_date = dal.FinishDate });
			}
		}

		public async Task<int?> ChangeItemPrice(ChangeItemPriceDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryFirstOrDefaultAsync<int?>($@"
						update 
							public.{quotes}Item{quotes}
						set 
							price = @price
						where
							id = @id						
						returning 1",
						new { id = dal.Id, finish_date = dal.Price });
			}
		}

		public Task<int?> ChangeItemStatus(ChangeItemStatusDalModel dal)
		{
			throw new NotImplementedException();
		}

		public async Task CreateItemAsync(CreateItemDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				try
				{
					await connection.QueryAsync(@$"
						insert into public.{quotes}Item{quotes}
							(order_id,							
							picture_id,							
							status,
							start_date) 
						values 
							(@orderId,							
							@pictureId,							
							@status,
							@startDate) ",
					new
					{
						orderId = dal.OrderId,						
						pictureId = dal.PictureId,
						status = dal.Status,
						startDate = dal.StartDate,						
					});
				}
				catch (PostgresException ex)
				{
					switch (ex.ConstraintName)
					{
						case "order_id":
							throw new InvalidOrderIdException();					
						case "picture_id":
							throw new InvalidPictureIdException();
						case "picture_id_unique":
							throw new PictureAlreadyBelongsToOtherItemException();
						default: throw;
					}
				}
			}
		}

		public async Task<IEnumerable<ItemDalModel>> GetItemsByAuthorId(int workerId)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryAsync<ItemDalModel>(@$"
					select
						id,
						price,
						status,
						start_date,
						finish_date,
						order_id,
						author_id,
						picture_id,
						customer_id						
					from 
						public.{quotes}Item{quotes}
					where
						id = @id",
						new { id = workerId }
				);
			}
		}

		/// <summary>
		/// Переделать с джоином
		/// </summary>
		/// <param name="customerId"></param>
		/// <returns></returns>
		public async Task<IEnumerable<ItemDalModel>> GetItemsByCustomerId(int customerId)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryAsync<ItemDalModel>(@$"
					select
						id,
						price,
						status,
						start_date,
						finish_date,
						order_id,
						author_id,
						picture_id,
						customer_id						
					from 
						public.{quotes}Item{quotes}
					where
						id = @id",
						new { id = customerId }
				);
			}
		}

		public async Task<IEnumerable<ItemDalModel>> GetItemsByOrderId(int orderId)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryAsync<ItemDalModel>(@$"
					select
						id,
						price,
						status,
						start_date,
						finish_date,
						order_id,
						author_id,
						picture_id,
						customer_id						
					from 
						public.{quotes}Item{quotes}
					where
						id = @id",
						new { id = orderId }
				);
			}
		}

		public Task<IEnumerable<ItemDalModel>> GetItemsWithoutAuthor()
		{
			throw new NotImplementedException();
		}
	}
}
