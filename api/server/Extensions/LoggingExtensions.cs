namespace Coevent.Api.Extensions;

using Serilog;

public static class LoggingExtensions
{
    public static IServiceCollection AddSerilogging(
        this IServiceCollection services, IConfiguration configuration
    )
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (environment != null && !environment.EndsWith("Local"))
        {

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Debug()
                .WriteTo.Console()
                .Enrich.WithProperty("Environment", environment)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
        return services;
    }
}
