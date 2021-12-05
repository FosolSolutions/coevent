namespace Coevent.Api.Areas.Admin.Mappings;

using Mapster;
using Entity = Coevent.Entities;

/// <summary>
/// OpeningMap class, provides mapping for mapster.
/// </summary>
public class OpeningMap : IRegister
{
    /// <summary>
    /// Register this map.
    /// </summary>
    /// <param name="config"></param>
    public void Register(TypeAdapterConfig config)
    {
        var ctor = typeof(Entity.Opening).GetConstructor(new[] { typeof(string), typeof(long) });
        config.NewConfig<Models.OpeningModel, Entity.Opening>()
            .MapToConstructor(ctor ?? null!);
    }
}
