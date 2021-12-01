namespace Coevent.Api.Mappings;

using Mapster;
using Entity = Coevent.Entities;

public class AudiColumnsMap : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Entity.AuditColumns, Models.AuditColumnsModel>()
            .Map(dest => dest.RowVersion, src => src.RowVersion == null ? null : Convert.ToBase64String(src.RowVersion));

        config.NewConfig<Models.AuditColumnsModel, Entity.AuditColumns>()
            .Map(dest => dest.RowVersion, src => src.RowVersion == null ? null : Convert.FromBase64String(src.RowVersion));
    }
}
