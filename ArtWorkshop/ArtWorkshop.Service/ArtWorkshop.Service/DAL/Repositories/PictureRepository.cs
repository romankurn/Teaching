using ArtWorkshop.Service.Config;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Models.Picture;
using ArtWorkshop.Service.DataBaseLayer.Repositories;
using ArtWorkshop.Service.Exceptions.Picture;
using Dapper;
using Npgsql;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Repositories
{
	public class PictureRepository : RepositoryBase, IPictureRepository
	{
		public PictureRepository(DBSetting dbSetting) : base(dbSetting)
		{

		}

		public async Task<int?> CreatePictureAsync(PictureCreateDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				try
				{
					return await connection.QueryFirstOrDefaultAsync<int?>($@"
						insert into public.{quotes}Picture{quotes} 
							(name, picture_type_id, canvas_type_id, gilding_type_id, size_id)
						values(
							@name,
							@pictureTypeId,
							@canvasTypeId,
							@gildingTypeId,
							@sizeId)
						returning id",
							new
							{
								name = string.IsNullOrEmpty(dal.Name) ? null : dal.Name,
								pictureTypeId = dal.PictureTypeId,
								canvasTypeId = dal.CanvasTypeId,
								sizeId = dal.SizeId,
								gildingTypeId = dal.GildingTypeId
							});
				}
				catch (PostgresException ex)
				{
					switch (ex.ConstraintName)
					{
						case "picture_type_id":
							throw new InvalidPictureTypeIdException();
						case "canvas_type_id":
							throw new InvalidCanvasTypeIdException();
						case "gilding_type_id":
							throw new InvalidGildingTypeIdException();
						case "size_id":
							throw new InvalidSizeIdException();
					}

					if (ex.ColumnName == "name")
						throw new EmptyNameException();

					return null;
				}
			}
		}
	}
}
