using ArtWorkshop.Service.BLL.Helpers;
using ArtWorkshop.Service.BLL.Interfaces;
using ArtWorkshop.Service.BLL.Services;
using ArtWorkshop.Service.BusinessLogicLayer.Interfaces;
using ArtWorkshop.Service.BusinessLogicLayer.Services;
using ArtWorkshop.Service.Config;
using ArtWorkshop.Service.DAL.Interfaces;
using ArtWorkshop.Service.DAL.Repositories;
using ArtWorkshop.Service.DataBaseLayer.Interfaces;
using ArtWorkshop.Service.DataBaseLayer.Repositories;
using ArtWorkshop.Service.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ArtWorkshop.Service
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var dbSetting = Configuration.GetSection(nameof(DBSetting)).Get<DBSetting>();

			services.AddSingleton(dbSetting);

			services.AddSingleton<IUserRepository, UserRepository>();
			services.AddSingleton<IRoleRepository, RoleRepository>();
			services.AddSingleton<IPictureTypeRepository, PictureTypeRepository>();
			services.AddSingleton<ICanvasTypeRepository, CanvasTypeRepository>();
			services.AddSingleton<IPictureRepository, PictureRepository>();
			services.AddSingleton<IGildingTypeRepository, GildingTypeRepository>();
			services.AddSingleton<ISizesRepository, SizesRepository>();
			services.AddSingleton<IOrderRepository, OrderRepository>();
			services.AddSingleton<IItemRepository, ItemRepository>();			


			services.AddSingleton<IUserService, UserService>();
			services.AddSingleton<IPictureTypeService, PictureTypeService>();
			services.AddSingleton<ICanvasTypeService, CanvasTypeService>();
			services.AddSingleton<IPictureService, PictureService>();
			services.AddSingleton<IGildingTypeService, GildingTypeService>();
			services.AddSingleton<ISizesService, SizesService>();
			services.AddSingleton<IOrderService, OrderService>();
			services.AddSingleton<IItemService, ItemService>();


			services.AddSingleton<FileReader>();


			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ArtWorkshop.Service", Version = "v1" });

				c.OperationFilter<AdduserIdHeaderParameter>();
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ArtWorkshop.Service v1"));
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
