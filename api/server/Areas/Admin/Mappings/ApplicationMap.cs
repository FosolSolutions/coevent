namespace Coevent.Api.Areas.Admin.Mappings;

using Mapster;
using Entity = Coevent.Entities;

/// <summary>
/// ApplicationMap class, provides mapping for mapster.
/// </summary>
public class ApplicationMap : IRegister
{
    /// <summary>
    /// Register this map.
    /// </summary>
    /// <param name="config"></param>
    public void Register(TypeAdapterConfig config)
    {
        var ctor = typeof(Entity.Application).GetConstructor(new[] { typeof(long), typeof(long), typeof(long) });
        config.NewConfig<Models.ApplicationModel, Entity.Application>()
            .MapToConstructor(ctor ?? null!);
    }
}
