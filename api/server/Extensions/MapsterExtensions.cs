using System.Reflection;
using System.Text.Json;
using Mapster;
using MapsterMapper;

namespace Coevent.Api.Extensions;

/// <summary>
/// MapsterExtensions static class, provides extension methods for mapster.
/// </summary>
public static class MapsterExtensions
{
    /// <summary>
    /// Add Mapster to the DI service collection.
    /// By default this will scan the assembly for all mappers that inherit IRegister.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static IServiceCollection AddMapster(this IServiceCollection services, Action<TypeAdapterConfig>? options = null)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetAssembly(typeof(MapsterExtensions)) ?? null!);

        options?.Invoke(config);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }

    /// <summary>
    /// Add Mapster to the DI service collection.
    /// By default this will scan the assembly for all mappers that inherit IRegister.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="serializerOptions"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static IServiceCollection AddMapster(this IServiceCollection services, JsonSerializerOptions serializerOptions, Action<TypeAdapterConfig>? options = null)
    {
        var config = TypeAdapterConfig.GlobalSettings;

        var optionsSerializer = Microsoft.Extensions.Options.Options.Create(serializerOptions);
        var assemblies = new[] { Assembly.GetAssembly(typeof(Startup)) };
        var registers = assemblies.Select(assembly => assembly?.GetTypes()
            .Where(x => typeof(IRegister).GetTypeInfo().IsAssignableFrom(x.GetTypeInfo()) && x.GetTypeInfo().IsClass && !x.GetTypeInfo().IsAbstract))
            .SelectMany(registerTypes =>
                registerTypes?.Select(registerType =>
                    (registerType.GetConstructor(Type.EmptyTypes) == null
                    ? (IRegister)(Activator.CreateInstance(registerType, new[] { optionsSerializer }) ?? null!)
                    : (IRegister)(Activator.CreateInstance(registerType) ?? null!))) ?? null!).ToList();

        config.Apply(registers);

        options?.Invoke(config);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
