using ArtWorkshop.Service.Config;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Models.GildingType;
using ArtWorkshop.Service.DataBaseLayer.Repositories;
using ArtWorkshop.Service.Exceptions.GildingType;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Repositories
{
	public class GildingTypeRepository : RepositoryBase, IGildingTypeRepository
	{
		public GildingTypeRepository(DBSetting dbSetting) : base(dbSetting)
		{

		}

		public async Task CreateGildingTypeAsync(string name)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				try
				{
					await connection.QueryAsync(@$"
						insert into public.{quotes}GildingType{quotes}
							(name) 
						values 
							(@name)",
					new
					{
						name = name
					});
				}
				catch (PostgresException e) when (e.ConstraintName == "gilding_type_name_unique")
				{
					throw new GildingTypeWithSameNameAlreadyExistsException();
				}
			}
		}

		public async Task<IEnumerable<GildingType>> GetGildingTypesAsync()
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryAsync<GildingType>(@$"
					select					
						id,
						name,
						position
					from public.{quotes}GildingType{quotes}
					order by position"
				);
			}
		}
	}
}
