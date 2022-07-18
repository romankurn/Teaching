using System.Collections.Generic;

using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;


namespace ArtWorkshop.Service.Swagger
{
	public class AdduserIdHeaderParameter : IOperationFilter
	{
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "UserId",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "int"
                }
            });
        }
    }
}
