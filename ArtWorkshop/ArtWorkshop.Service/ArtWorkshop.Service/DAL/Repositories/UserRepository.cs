using ArtWorkshop.Service.Config;
using ArtWorkshop.Service.DAL.Models.User;
using ArtWorkshop.Service.DataBaseLayer.Interfaces;
using ArtWorkshop.Service.DataBaseLayer.Models.User;
using ArtWorkshop.Service.Exceptions;
using ArtWorkshop.Service.Exceptions.User;
using Dapper;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DataBaseLayer.Repositories
{
	public class UserRepository : RepositoryBase, IUserRepository
	{
		public UserRepository(DBSetting dbSetting) : base(dbSetting)
		{
			
		}	

		public async Task<User> GetUserByIdAsync(int userId)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryFirstOrDefaultAsync<User>(@$"
					select 
						id as Id,
						email as Email,
						first_name as FirstName,
						second_name as SecondName,
						role_id as RoleId
					from public.{quotes}Users{quotes}
					where id = @userId",
					new { userId }
					);
			}
		}

		public async Task SignUpUserAsync(UserSignUpDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				try
				{
					await connection.QueryAsync(@$"
						insert into public.{quotes}Users{quotes}
						(
							email,
							password, 
							first_name,
							second_name, 
							role_id)

						values (
							@email, 
							@password, 
							@firstName, 
							@secondName, 
						(select id from public.{quotes}Role{quotes} where name = @role)
						)",
					new
					{
						email = dal.Email,
						password = dal.Password,
						firstName = dal.FirstName,
						secondName = dal.SecondName,
						role = dal.Role
					});
				}
				catch (PostgresException e) when (e.ConstraintName == "email_unique")
				{
					throw new UserWithSameEmailAlreadyExistsException();
				}
			}
		}

		public async Task<bool> CheckUserEmailAsync(string email)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryFirstOrDefaultAsync<bool>(@$"					
					select exists(select email
					from public.{quotes}Users{quotes}
					where 
						email = @email
						and is_deleted = false)",
					new { email }
					);
			}
		}

		public async Task<int?> CheckUserPasswordAsync(UserSignInDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryFirstOrDefaultAsync<int?>(@$"					
					select id 
					from public.{quotes}Users{quotes}
					where 
						email = @email 
						and password = @password
						and is_deleted = false",
					new { email = dal.Email, password = dal.Password});
			}
		}

		public async Task<int?> ChangeUserDataAsync(UserChangeDataDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				 return await connection.QueryFirstOrDefaultAsync<int?>($@"
					update 
						public.{quotes}Users{quotes}
					set
						first_name = @firstName,
						second_name = @secondName
					where
						id = @id
						and is_deleted = false
					returning 1",
					new { id = dal.Id, firstName = dal.FirstName, secondName = dal.SecondName });
			}
		}

		public async Task<int?> DeleteUserAsync(int userId)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryFirstOrDefaultAsync<int?>($@"
					update 
						public.{quotes}Users{quotes}
					set
						is_deleted = true
					where
						id = @id
						and is_deleted = false
					returning 1",
					new {id = userId});
			}
		}
	}
}
