namespace Coevent.Api;

using Coevent.Core.Extensions;
using Coevent.Api.Authorization;
using Coevent.Api.Extensions;
using Coevent.Api.Middleware;
using Coevent.Dal.Extensions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Startup class, provides a way to startup the .netcore RESTful API and configure it.
/// </summary>
[ExcludeFromCodeCoverage]
public class Startup
{
    #region Properties
    /// <summary>
    /// get - The application configuration settings.
    /// </summary>
    /// <value></value>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// get/set - The environment settings for the application.
    /// </summary>
    /// <value></value>
    public IWebHostEnvironment Environment { get; }
    #endregion

    #region Constructors
    /// <summary>
    /// Creates a new instances of a Startup class.
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="env"></param>
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        this.Configuration = configuration;
        this.Environment = env;
    }
    #endregion

    #region Methods
    /// <summary>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOptions();
        services.AddSingleton(this.Configuration);
        services.AddSingleton(this.Environment);

        services.AddJsonSerializerOptions(this.Configuration);
        services.AddMapster(this.Configuration.CreateJsonSerializerOptions(), options =>
        {
            options.Default.IgnoreNonMapped(false);
            options.Default.IgnoreNullValues(true);
            options.AllowImplicitDestinationInheritance = true;
            options.AllowImplicitSourceInheritance = true;
            options.Default.UseDestinationValue(member =>
                member.SetterModifier == AccessModifier.None &&
                member.Type.IsGenericType &&
                member.Type.GetGenericTypeDefinition() == typeof(ICollection<>));
        });

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                this.Configuration.CreateJsonSerializerOptions(options.JsonSerializerOptions);
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddMvcCore()
            .AddJsonOptions(options =>
            {
                this.Configuration.CreateJsonSerializerOptions(options.JsonSerializerOptions);
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddHttpClient();
        services.AddCoeventDal(this.Configuration, this.Environment);
        services.AddSingleton<IAuthorizationHandler, RealmAccessRoleHandler>();
        services.AddHttpContextAccessor();
        services.AddTransient<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>()?.HttpContext?.User ?? new ClaimsPrincipal());

        services.AddCustomwagger();

        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.All;
            options.AllowedHosts = this.Configuration.GetValue<string>("AllowedHosts")?.Split(';').ToList<string>() ?? new List<string>();
        });

        services.AddCors(options =>
        {
            var withOrigins = this.Configuration.GetSection("Cors:WithOrigins").Value?.Split(" ") ?? Array.Empty<string>();
            if (withOrigins.Any())
            {
                options.AddPolicy(name: "allowedOrigins",
                    builder =>
                    {
                        builder
                            .WithOrigins(withOrigins)
                            .AllowAnyHeader()
                            .AllowAnyMethod(); ;
                    });
            }
        });

        services.AddCoeventAuthentication(this.Configuration);
    }

    /// <summary>
    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <param name="provider"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
    {
        if (!env.IsProduction())
        {
            app.UseDeveloperExceptionPage();
            // app.UseMigrationsEndPoint();
        }

        app.UsePathBase(this.Configuration.GetValue<string>("BaseUrl"));
        app.UseForwardedHeaders();

        app.UseCustomSwagger(this.Configuration, provider);

        app.UseMiddleware(typeof(ErrorHandlingMiddleware));
        app.UseMiddleware(typeof(ResponseTimeMiddleware));

        //app.UseHttpsRedirection();

        app.UseRouting();
        app.UseCors("allowedOrigins");

        app.UseMiddleware(typeof(LogRequestMiddleware));

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(config =>
        {
            config.MapControllers();
        });
    }
    #endregion
}
