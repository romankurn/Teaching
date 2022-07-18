using ArtWorkshop.Service.Config;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Models.Order;
using ArtWorkshop.Service.DataBaseLayer.Repositories;
using ArtWorkshop.Service.Exceptions.Order;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Repositories
{
	public class OrderRepository : RepositoryBase, IOrderRepository
	{
		public OrderRepository(DBSetting dbSetting) : base(dbSetting)
		{

		}

		public async Task<int?> ChangeOrderData(ChangeOrderDataDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				try
				{
					return await connection.QueryFirstOrDefaultAsync<int?>(@$"
					update
						public.{quotes}Order{quotes}
					set
						reciever_address = coalesce(@recieverAddress, reciever_address),
						status = coalesce(@status, status),
						delivery_fee = coalesce(@deliveryFee, delivery_fee),
						delivery_type_id = coalesce(@deliveryTypeId, delivery_type_id)
					where id = @id
						returning 1",
						new
						{
							recieverAddress = dal.RecieverAddress,
							status = dal.Status,
							deliveryFee = dal.DeliveryFee,
							deliveryTypeId = dal.DeliveryTypeId,
							id = dal.Id
						});
				}
				catch(PostgresException ex) when (ex.ConstraintName == "delivery_type_id")
				{
					throw new InvalidDeliveryTypeIdException();
				}
			}

		}

		public async Task<int?> CreateOrderAsync(CreateOrderDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				try
				{
					return await connection.QueryFirstOrDefaultAsync<int?>(@$"
						insert into public.{quotes}Order{quotes}
						(
							customer_id,
							reciever_address,
							status
						) 
						values 
						(
							@customerId,
							@recieverAddress,
							@status
						)
						returning id",
					new
					{
						customerId = dal.CustomerId,
						recieverAddress = dal.RecieverAddress,
						status = dal.Status,
					});
				}
				catch (PostgresException ex)
				{
					switch (ex.ConstraintName)
					{
						case "customer_id":
							throw new InvalidCustomerIdException();
						case "delivery_type_id":
							throw new InvalidDeliveryTypeIdException();
						default:
							throw new Exception();
					}
				}
			}
		}

		public async Task<IEnumerable<OrderDalModel>> GetOrdersByStatusAsync(string status)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{				
				return await connection.QueryAsync<OrderDalModel>(@$"
				select
				o.id,
				o.reciever_address as RecieverAddress,
				o.status,
				o.delivery_fee as DeliveryFee,
				o.customer_id as CustomerId,
				o.delivery_type_id as DeliveryTypeId
				from public.{quotes}Order{quotes} o
				JOIN {quotes}Item{quotes} i ON i.order_id = o.Id
				where i.status = 'Init'",
				new { requestStatus = status });
			}
		}

		public async Task<IEnumerable<OrderDalModel>> GetOrdersByUserIdAsync(int id)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryAsync<OrderDalModel>(@$"
					select
						id,
						customer_id as CustomerId,
						delivery_type_id as DeliveryTypeId,
						reciever_address as RecieverAddress,
						status,
						delivery_fee as DeliveryFee
					from public.{quotes}Order{quotes}
					where customer_id = @customerId",
				new { customerId = id });
			}
		}
	}
}
