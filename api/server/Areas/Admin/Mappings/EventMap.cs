namespace Coevent.Api.Areas.Admin.Mappings;

using Mapster;
using Entity = Coevent.Entities;

/// <summary>
/// EventMap class, provides mapping for mapster.
/// </summary>
public class EventMap : IRegister
{
    /// <summary>
    /// Register this map.
    /// </summary>
    /// <param name="config"></param>
    public void Register(TypeAdapterConfig config)
    {
        var ctor = typeof(Entity.Event).GetConstructor(new[] { typeof(string), typeof(long) });
        config.NewConfig<Models.EventModel, Entity.Event>()
            .MapToConstructor(ctor ?? null!);
    }
}
