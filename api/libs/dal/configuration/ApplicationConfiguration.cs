namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ApplicationConfiguration : AuditColumnsConfiguration<Application>
{
    protected override void OnConfigure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.UserId).IsRequired();
        builder.Property(m => m.OpeningId).IsRequired();
        builder.Property(m => m.EventOccurrenceId).IsRequired();
        builder.Property(m => m.Status).IsRequired();

        builder.HasOne(m => m.User).WithMany(m => m.Applications).HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(m => m.OpeningOccurrence).WithMany(m => m.Applications).HasForeignKey(m => new { m.OpeningId, m.EventOccurrenceId }).OnDelete(DeleteBehavior.Cascade);
    }
}