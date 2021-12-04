namespace Coevent.Api.Extensions;

using Serilog;

/// <summary>
/// WebHostBuilderContextExtensions static class, provides extension methods for WebHostBuilderContext objects.
/// </summary>
public static class WebHostBuilderContextExtensions
{
    /// <summary>
    /// Applies configuration for web application.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="builder"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static IConfigurationBuilder ApplyConfiguration(this WebHostBuilderContext? context, IConfigurationBuilder builder, string[] args)
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

    /// <summary>
    /// Apply configures to Serilog.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="config"></param>
    public static void ApplyConfiguration(this WebHostBuilderContext context, LoggerConfiguration config)
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
