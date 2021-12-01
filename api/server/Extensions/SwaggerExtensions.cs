using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Coevent.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddCustomwagger(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, Swagger.ConfigureSwaggerOptions>();
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new HeaderApiVersionReader("api-version");
            // options.DefaultApiVersion = new ApiVersion(1, 0);
        });
        services.AddVersionedApiExplorer(options =>
        {
            // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            // note: the specified format code will format the version as "'v'major[.minor][-status]"
            options.GroupNameFormat = "'v'VVV";

            // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
            // can also be used to control the format of the API version in route templates
            options.SubstituteApiVersionInUrl = true;

        });

        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations(false, true);
            options.CustomSchemaIds(o => o.FullName);
            options.OperationFilter<Swagger.SwaggerDefaultValues>();
            options.DocumentFilter<Swagger.SwaggerDocumentFilter>();
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Description = "Please enter into field the word 'Bearer' following by space and JWT",
                Type = SecuritySchemeType.ApiKey
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }

    public static void UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration, IApiVersionDescriptionProvider provider, string prefix = "swagger")
    {
        app.UseSwagger(options =>
        {
            options.RouteTemplate = configuration.GetValue<string>("Swagger:RouteTemplate") ?? $"/{prefix}/{{documentname}}/swagger.json";
        });
        app.UseSwaggerUI(options =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint(String.Format(configuration.GetValue<string>("Swagger:EndpointPath") ?? $"/{prefix}/{0}/swagger.json", description.GroupName), description.GroupName);
            }
            options.RoutePrefix = configuration.GetValue<string>("Swagger:RoutePrefix") ?? prefix;
        });
    }
}
