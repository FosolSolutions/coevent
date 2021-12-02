namespace Coevent.Api.Mappings;

using Mapster;
using Entity = Coevent.Entities;

public class UserMap : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Entity.UserClaim, KeyValuePair<string, string>>()
            .ConstructUsing(s => new KeyValuePair<string, string>(s.Name, s.Value));

        config.NewConfig<Entity.Role, string>()
            .Map(dest => dest, src => src.Name);
    }
}
