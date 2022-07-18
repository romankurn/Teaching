using ArtWorkshop.Service.Config;

namespace ArtWorkshop.Service.DataBaseLayer.Repositories
{
	public abstract class RepositoryBase
	{
		protected readonly string _connectionString;
		protected readonly string quotes = "\"";

		protected RepositoryBase(DBSetting dbSetting)
		{
			_connectionString = dbSetting.ConnectionString;
		}
	}
}
