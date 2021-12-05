namespace Coevent.Api.Areas.Admin.Mappings;

using Mapster;
using Entity = Coevent.Entities;

/// <summary>
/// CalendarMap class, provides mapping for mapster.
/// </summary>
public class CalendarMap : IRegister
{
    /// <summary>
    /// Register this map.
    /// </summary>
    /// <param name="config"></param>
    public void Register(TypeAdapterConfig config)
    {
        var ctor = typeof(Entity.Calendar).GetConstructor(new[] { typeof(string), typeof(int) });
        config.NewConfig<Models.CalendarModel, Entity.Calendar>()
            .MapToConstructor(ctor ?? null!);
    }
}
