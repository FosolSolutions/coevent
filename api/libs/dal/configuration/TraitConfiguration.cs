namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TraitConfiguration : AuditColumnsConfiguration<Trait>
{
    protected override void OnConfigure(EntityTypeBuilder<Trait> builder)
    {
        builder.ToTable("Traits");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.AccountId).IsRequired();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Description).IsRequired(false).HasMaxLength(2000);
        builder.Property(m => m.IsDisabled).IsRequired();

        builder.HasOne(m => m.Account).WithMany(m => m.Traits).HasForeignKey(m => m.AccountId).OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(m => new { m.AccountId, m.Name }).IsUnique(true);
    }
}
