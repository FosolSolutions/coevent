namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OpeningCriteriaConfiguration : AuditColumnsConfiguration<OpeningCriteria>
{
    protected override void OnConfigure(EntityTypeBuilder<OpeningCriteria> builder)
    {
        builder.ToTable("OpeningCriterias");

        builder.HasKey(m => new { m.OpeningId, m.CriteriaId, m.TraitId });
        builder.Property(m => m.OpeningId).ValueGeneratedNever();
        builder.Property(m => m.CriteriaId).ValueGeneratedNever();
        builder.Property(m => m.TraitId).ValueGeneratedNever();

        builder.HasOne(m => m.Opening).WithMany(m => m.OpeningCriterias).HasForeignKey(m => m.OpeningId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(m => m.Criteria).WithMany(m => m.OpeningCriterias).HasForeignKey(m => m.CriteriaId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(m => m.Trait).WithMany(m => m.OpeningCriterias).HasForeignKey(m => m.TraitId).OnDelete(DeleteBehavior.Restrict);
    }
}
