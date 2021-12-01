namespace Coevent.Api.Areas.Admin.Mappings;

using Mapster;
using Entity = Coevent.Entities;

public class AccountMap : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        var ctor = typeof(Entity.Account).GetConstructor(new[] { typeof(string), typeof(long), typeof(string) });
        config.NewConfig<Models.AccountModel, Entity.Account>()
            .MapToConstructor(ctor ?? null!);
    }
}
