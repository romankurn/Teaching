using ArtWorkshop.Service.Config;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Models.Sizes;
using ArtWorkshop.Service.DataBaseLayer.Repositories;
using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Repositories
{
	public class SizesRepository : RepositoryBase, ISizesRepository
	{
		public SizesRepository(DBSetting dbSetting) : base(dbSetting)
		{

		}

		public async Task<IEnumerable<SizesDalModel>> GetSizesAsync()
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryAsync<SizesDalModel>(@$"
					select
						id,
						size,
						position
					from public.{quotes}Sizes{quotes}
					order by position"
				);
			}
		}
	}
}
