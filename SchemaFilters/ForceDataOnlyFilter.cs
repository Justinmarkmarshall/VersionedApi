using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VersionedApi.SchemaFilters
{
    public class ForceDateOnlyFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(DateTime) &&
                context.MemberInfo?.DeclaringType?.FullName?.Contains(".v1.") == true)
            {
                // Override the date-time format to just show date
                schema.Format = "date"; // This makes Swagger use yyyy-MM-dd
            }
        }
    }
}