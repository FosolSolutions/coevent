namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OpeningOccurrenceConfiguration : AuditColumnsConfiguration<OpeningOccurrence>
{
    protected override void OnConfigure(EntityTypeBuilder<OpeningOccurrence> builder)
    {
        builder.ToTable("OpeningOccurrences");

        builder.HasKey(m => new { m.OpeningId, m.EventOccurrenceId });
        builder.Property(m => m.OpeningId).ValueGeneratedNever();
        builder.Property(m => m.EventOccurrenceId).ValueGeneratedNever();
        builder.Property(m => m.Status).IsRequired();

        builder.HasOne(m => m.Opening).WithMany(m => m.OpeningOccurrences).HasForeignKey(m => m.OpeningId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(m => m.EventOccurrence).WithMany(m => m.OpeningOccurrences).HasForeignKey(m => m.EventOccurrenceId).OnDelete(DeleteBehavior.ClientNoAction);
    }
}
