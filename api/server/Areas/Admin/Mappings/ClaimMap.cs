namespace Coevent.Api.Areas.Admin.Mappings;

using Mapster;
using Entity = Coevent.Entities;

/// <summary>
/// ClaimMap class, provides mapping for mapster.
/// </summary>
public class ClaimMap : IRegister
{
    /// <summary>
    /// Register this map.
    /// </summary>
    /// <param name="config"></param>
    public void Register(TypeAdapterConfig config)
    {
        var ctor = typeof(Entity.Claim).GetConstructor(new[] { typeof(long), typeof(string) });
        config.NewConfig<Models.ClaimModel, Entity.Claim>()
            .MapToConstructor(ctor ?? null!);
    }
}
