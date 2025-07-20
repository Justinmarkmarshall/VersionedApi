using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Enables /v{version}/
});

builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

// pairs the API versioning with the Swagger generator
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "VersionedApi", Version = "v1" });
    options.SwaggerDoc("v2", new OpenApiInfo { Title = "VersionedApi", Version = "v2" });

    //custom filters for what to show in the request defaults
    options.SchemaFilter<VersionedApi.SchemaFilters.ForceDateOnlyFilter>();
});

var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var desc in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", $"API {desc.GroupName.ToUpperInvariant()}");
    }
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
