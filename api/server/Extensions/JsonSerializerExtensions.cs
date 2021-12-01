namespace Coevent.Api.Extensions;

using Coevent.Core.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class JsonSerializerExtensions
{
    public static IServiceCollection AddJsonSerializerOptions(this IServiceCollection services, IConfiguration configuration)
    {
        var jsonSerializerOptions = new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = configuration["Serialization:Json:DefaultIgnoreCondition"].TryParseEnum<JsonIgnoreCondition>(),
            PropertyNameCaseInsensitive = configuration["Serialization:Json:PropertyNameCaseInsensitive"].TryParseBoolean(true),
            PropertyNamingPolicy = configuration["Serialization:Json:PropertyNamingPolicy"] == nameof(JsonNamingPolicy.CamelCase) ? JsonNamingPolicy.CamelCase : null,
            WriteIndented = configuration["Serialization:Json:WriteIndented"].TryParseBoolean(true)
        };
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
