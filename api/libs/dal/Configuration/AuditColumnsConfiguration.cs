namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public abstract class AuditColumnsConfiguration<T> : IEntityTypeConfiguration<T>
    where T : AuditColumns
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(m => m.CreatedOn).IsRequired().HasColumnType("DATETIME2").HasDefaultValueSql("GETUTCDATE()");
        builder.Property(m => m.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(m => m.UpdatedOn).IsRequired().HasColumnType("DATETIME2").HasDefaultValueSql("GETUTCDATE()");
        builder.Property(m => m.UpdatedBy).IsRequired().HasMaxLength(50);
        builder.Property(m => m.RowVersion).IsRowVersion();

        OnConfigure(builder);
    }

    protected abstract void OnConfigure(EntityTypeBuilder<T> builder);
}