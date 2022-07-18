using ArtWorkshop.Service.Config;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Models.PictureType;
using ArtWorkshop.Service.DataBaseLayer.Repositories;
using ArtWorkshop.Service.Exceptions.PictureType;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtWorkshop.Service.DAL.Repositories
{
	public class PictureTypeRepository : RepositoryBase, IPictureTypeRepository
	{
		public PictureTypeRepository(DBSetting dbSetting) : base(dbSetting)
		{
		}

		public async Task<IEnumerable<PictureType>> GetPictureTypesAsync()
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				return await connection.QueryAsync<PictureType>(@$"
					select
						id,
						name,
						template
					from public.{quotes}PictureType{quotes}"
				);
			}
		}

		public async Task CreatePictureTypeAsync(PictureTypeCreateDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				try
				{
					await connection.QueryAsync(@$"
						insert into public.{quotes}PictureType{quotes}
							(
								name, 
								template) 
						values 
							(
								@name,
								@path)",
					new
					{
						name = dal.Name,
						path = dal.PicturePath
					});
				}
				catch (PostgresException e) when (e.ConstraintName == "name_unique") 
				{
					throw new PictyreTypeWithSameNameAlreadyExistsException();
				}
			}
		}

		public async Task<int?> ChangePictureTypeDataAsync(PictureTypeChangeDataDalModel dal)
		{
			using (var connection = new NpgsqlConnection(_connectionString))
			{
				try
				{
					return await connection.QueryFirstOrDefaultAsync<int?>($@"
					update 
						public.{quotes}PictureType{quotes}
					set
						name = @name,
						template = @template
					where
						id = @id
					returning 1",
						new { id = dal.Id, name = dal.Name, template = dal.PicturePath });
				}
				catch (PostgresException e) when (e.ConstraintName == "name_unique") 
				{
					throw new PictyreTypeWithSameNameAlreadyExistsException();
				}
			}

		}
	}
}

