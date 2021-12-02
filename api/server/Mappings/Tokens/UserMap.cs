namespace Coevent.Api.Mappings;

using Mapster;
using Entity = Coevent.Entities;

/// <summary>
/// get/set -
/// </summary>
public class UserMap : IRegister
{
    /// <summary>
    /// get/set -
    /// </summary>
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Entity.UserClaim, KeyValuePair<string, string>>()
            .ConstructUsing(s => new KeyValuePair<string, string>(s.Name, s.Value));

        config.NewConfig<Entity.Role, string>()
            .Map(dest => dest, src => src.Name);
    }
}
