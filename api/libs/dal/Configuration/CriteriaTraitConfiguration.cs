namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CriteriaTraitConfiguration : AuditColumnsConfiguration<CriteriaTrait>
{
    protected override void OnConfigure(EntityTypeBuilder<CriteriaTrait> builder)
    {
        builder.ToTable("CriteriaTraits");

        builder.HasKey(m => new { m.CriteriaId, m.TraitId });
        builder.Property(m => m.CriteriaId).IsRequired().ValueGeneratedNever();
        builder.Property(m => m.TraitId).IsRequired().ValueGeneratedNever();
        builder.Property(m => m.Formula).IsRequired();
        builder.Property(m => m.Value).IsRequired().HasMaxLength(500);
        builder.Property(m => m.IsRequired).IsRequired();
        builder.Property(m => m.IsDisabled).IsRequired();

        builder.HasOne(m => m.Criteria).WithMany(m => m.CriteriaTraits).HasForeignKey(m => m.CriteriaId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(m => m.Trait).WithMany(m => m.CriteriaTraits).HasForeignKey(m => m.TraitId).OnDelete(DeleteBehavior.Cascade);
    }
}