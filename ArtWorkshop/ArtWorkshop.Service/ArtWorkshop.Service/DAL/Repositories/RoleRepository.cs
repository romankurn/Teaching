using ArtWorkshop.Service.Config;
using ArtWorkshop.Service.DataBaseLayer.Interfaces;
using Dapper;
using Npgsql;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DataBaseLayer.Repositories
{
	public class RoleRepository : RepositoryBase, IRoleRepository
	{
		public RoleRepository(DBSetting dbSetting) : base(dbSetting)
		{

		}

		public async Task<string> GetRoleByUserIdAsync(int userId)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryFirstOrDefaultAsync<string>(@$"
					select 
						r.name
					from public.{quotes}Role{quotes} r
					join public.{quotes}Users{quotes} u
						on u.role_id = r.id
						where u.id = @userId",
					new { userId }
					);
			}
		}
	}
}
