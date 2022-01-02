namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CriteriaConfiguration : AuditColumnsConfiguration<Criteria>
{
    protected override void OnConfigure(EntityTypeBuilder<Criteria> builder)
    {
        builder.ToTable("Criterias");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.AccountId).IsRequired();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Description).IsRequired().HasMaxLength(2000);

        builder.HasOne(m => m.Account).WithMany(m => m.Criterias).HasForeignKey(m => m.AccountId).OnDelete(DeleteBehavior.ClientCascade);

        builder.HasIndex(m => new { m.AccountId, m.Name }).IsUnique(true);
    }
}
