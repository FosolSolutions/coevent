
namespace Coevent.Core.Extensions;

using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class JsonSerializerOptionsExtensions
{
    public static JsonSerializerOptions CreateJsonSerializerOptions(this IConfiguration configuration)
    {
        return configuration.CreateJsonSerializerOptions(new JsonSerializerOptions());
    }

    public static JsonSerializerOptions CreateJsonSerializerOptions(this IConfiguration configuration, JsonSerializerOptions options)
    {
        options.DefaultIgnoreCondition = configuration["Serialization:Json:DefaultIgnoreCondition"].TryParseEnum<JsonIgnoreCondition>();
        options.PropertyNameCaseInsensitive = configuration["Serialization:Json:PropertyNameCaseInsensitive"].TryParseBoolean(true);
        options.PropertyNamingPolicy = configuration["Serialization:Json:PropertyNamingPolicy"] == nameof(JsonNamingPolicy.CamelCase) ? JsonNamingPolicy.CamelCase : null;
        options.WriteIndented = configuration["Serialization:Json:WriteIndented"].TryParseBoolean(true);
        return options;
    }
}
