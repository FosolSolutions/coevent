namespace Coevent.Api.Areas.Admin.Mappings;

using Mapster;
using Entity = Coevent.Entities;

/// <summary>
/// UserMap class, provides mapping for mapster.
/// </summary>
public class UserMap : IRegister
{
    /// <summary>
    /// Register this map.
    /// </summary>
    /// <param name="config"></param>
    public void Register(TypeAdapterConfig config)
    {
        var ctor = typeof(Entity.User).GetConstructor(new[] { typeof(string), typeof(long), typeof(long), typeof(long) });
        config.NewConfig<Models.UserModel, Entity.User>()
            .MapToConstructor(ctor ?? null!);
    }
}
