namespace Coevent.Api.Extensions;

using Coevent.Core.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class JsonSerializerExtensions
{
    public static IServiceCollection AddJsonSerializerOptions(this IServiceCollection services, IConfiguration configuration)
    {
        var jsonSerializerOptions = configuration.CreateJsonSerializerOptions();
        services.Configure<JsonSerializerOptions>(options =>
        {
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.PropertyNameCaseInsensitive = jsonSerializerOptions.PropertyNameCaseInsensitive;
            options.PropertyNamingPolicy = jsonSerializerOptions.PropertyNamingPolicy;
            options.WriteIndented = jsonSerializerOptions.WriteIndented;
            options.Converters.Add(new JsonStringEnumConverter());
        });
        return services;
    }
}
