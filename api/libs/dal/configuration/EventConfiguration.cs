namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EventConfiguration : AuditColumnsConfiguration<Event>
{
    protected override void OnConfigure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).IsRequired(false).HasMaxLength(2000);
        builder.Property(m => m.EventType).IsRequired();
        builder.Property(m => m.IsDisabled).IsRequired();
        builder.Property(m => m.AccountId).IsRequired();
        builder.Property(m => m.Status).IsRequired();
        builder.Property(m => m.StartOn).IsRequired().HasColumnType("DATETIME2");
        builder.Property(m => m.EndOn).IsRequired().HasColumnType("DATETIME2");
        builder.Property(m => m.ScheduleId).IsRequired(false);
        builder.Property(m => m.DisplayOrder).IsRequired();

        builder.HasOne(m => m.Account).WithMany(m => m.Events).HasForeignKey(m => m.AccountId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(m => m.Schedule).WithMany(m => m.Events).HasForeignKey(m => m.ScheduleId).OnDelete(DeleteBehavior.Restrict);
    }
}
