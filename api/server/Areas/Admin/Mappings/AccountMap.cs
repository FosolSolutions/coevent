namespace Coevent.Api.Areas.Admin.Mappings;

using Mapster;
using Entity = Coevent.Entities;

/// <summary>
/// AccountMap class, provides mapping for mapster.
/// </summary>
public class AccountMap : IRegister
{
    /// <summary>
    /// Register this map.
    /// </summary>
    /// <param name="config"></param>
    public void Register(TypeAdapterConfig config)
    {
        var ctor = typeof(Entity.Account).GetConstructor(new[] { typeof(string), typeof(long) });
        config.NewConfig<Models.AccountModel, Entity.Account>()
            .MapToConstructor(ctor ?? null!);
    }
}
