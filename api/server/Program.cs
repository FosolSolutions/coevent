namespace Coevent.Api;

using Coevent.Api.Extensions;
using Serilog;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore;

/// <summary>
/// Program class, provides the main program starting point for the Geo-spatial application.
/// </summary>
[ExcludeFromCodeCoverage]
public class Program
{
    /// <summary>
    /// The primary entry point for the application.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        var builder = CreateWebHostBuilder(args);
        builder.Build().Run();
    }

    /// <summary>
    /// Create a default configuration and setup for a web application.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        DotNetEnv.Env.Load();
        var config = WebHostBuilderContextExtensions.ApplyConfiguration(null, new ConfigurationBuilder(), args).Build();
        var builder = WebHost.CreateDefaultBuilder(args);

        return WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) => context.ApplyConfiguration(config, args))
            .UseSerilog(WebHostBuilderContextExtensions.ApplyConfiguration)
            .UseUrls(config.GetValue<string>("ASPNETCORE_URLS"))
            .UseStartup<Startup>();
    }
}
