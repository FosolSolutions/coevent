namespace Coevent.Api;

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
        var config = ApplyConfiguration(null, new ConfigurationBuilder(), args).Build();
        var builder = WebHost.CreateDefaultBuilder(args);

        return WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) => ApplyConfiguration(context, config, args))
            .UseSerilog(ApplyConfiguration)
            .UseUrls(config.GetValue<string>("ASPNETCORE_URLS"))
            .UseStartup<Startup>();
    }

    private static IConfigurationBuilder ApplyConfiguration(WebHostBuilderContext? context, IConfigurationBuilder builder, string[] args)
    {
        var env = context?.HostingEnvironment.EnvironmentName ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        builder.AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);
        builder.AddJsonFile("connectionstrings.json", optional: true, reloadOnChange: true);
        builder.AddJsonFile($"connectionstrings.{env}.json", optional: true, reloadOnChange: true);
        builder.AddEnvironmentVariables();
        builder.AddCommandLine(args);
        return builder;
    }

    private static void ApplyConfiguration(WebHostBuilderContext context, LoggerConfiguration config)
    {
        var env = context.HostingEnvironment.EnvironmentName;
        config.ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .WriteTo.Console()
            .WriteTo.Seq(context.Configuration.GetValue<string>("SEQ_API_INGESTION_URL"))
            .Enrich.WithProperty("Environment", env);

        if (!context.HostingEnvironment.IsProduction())
            config.WriteTo.Debug();
    }
}
