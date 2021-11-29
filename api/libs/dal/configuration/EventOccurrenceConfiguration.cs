namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EventOccurrenceConfiguration : AuditColumnsConfiguration<EventOccurrence>
{
    protected override void OnConfigure(EntityTypeBuilder<EventOccurrence> builder)
    {
        builder.ToTable("EventOccurrences");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).IsRequired(false).HasMaxLength(2000);
        builder.Property(m => m.EventId).IsRequired();
        builder.Property(m => m.IsDisabled).IsRequired();
        builder.Property(m => m.Status).IsRequired();
        builder.Property(m => m.StartOn).IsRequired().HasColumnType("DATETIME2");
        builder.Property(m => m.EndOn).IsRequired().HasColumnType("DATETIME2");
        builder.Property(m => m.DisplayOrder).IsRequired();

        builder.HasOne(m => m.Event).WithMany(m => m.Occurrences).HasForeignKey(m => m.EventId).OnDelete(DeleteBehavior.Cascade);
    }
}