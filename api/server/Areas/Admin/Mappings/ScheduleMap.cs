namespace Coevent.Api.Areas.Admin.Mappings;

using System;
using Mapster;
using Entity = Coevent.Entities;

/// <summary>
/// ScheduleMap class, provides mapping for mapster.
/// </summary>
public class ScheduleMap : IRegister
{
    /// <summary>
    /// Register this map.
    /// </summary>
    /// <param name="config"></param>
    public void Register(TypeAdapterConfig config)
    {
        var ctor = typeof(Entity.Schedule).GetConstructor(new[] { typeof(string), typeof(long), typeof(TimeSpan), typeof(TimeSpan) });
        config.NewConfig<Models.ScheduleModel, Entity.Schedule>()
            .MapToConstructor(ctor ?? null!);
    }
}
