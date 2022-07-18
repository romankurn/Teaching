using ArtWorkshop.Service.Config;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Models.CanvasType;
using ArtWorkshop.Service.DataBaseLayer.Repositories;
using ArtWorkshop.Service.Exceptions.CanvasType;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Repositories
{
	public class CanvasTypeRepository : RepositoryBase, ICanvasTypeRepository
	{
		public CanvasTypeRepository(DBSetting dbSetting) : base(dbSetting)
		{

		}

		public async Task CreateCanvasTypeAsync(string name)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				try
				{
					await connection.QueryAsync(@$"
						insert into public.{quotes}CanvasType{quotes}
							(name) 
						values 
							(@name)",
					new
					{
						name = name
					});
				}
				catch (PostgresException e) when (e.ConstraintName == "canvas_name_unique") 
				{
					throw new CanvasTypeWithSameNameAlreadyExistsException();
				}
			}
		}

		public async Task<IEnumerable<CanvasType>> GetCanvasTypesAsync()
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryAsync<CanvasType>(@$"
					select
						id,
						name
					from public.{quotes}CanvasType{quotes}"
				);
			}
		}
	}
}
