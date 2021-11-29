namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ScheduleConfiguration : AuditColumnsConfiguration<Schedule>
{
    protected override void OnConfigure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("Schedules");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).IsRequired(false).HasMaxLength(2000);
        builder.Property(m => m.AccountId).IsRequired();
        builder.Property(m => m.IsDisabled).IsRequired();
        builder.Property(m => m.StartOnTime).IsRequired().HasColumnType("TIME2");
        builder.Property(m => m.EndOnTime).IsRequired().HasColumnType("TIME2");
        builder.Property(m => m.DaysOfWeek).IsRequired();
        builder.Property(m => m.Months).IsRequired();
        builder.Property(m => m.RepeatType).IsRequired();
        builder.Property(m => m.RepeatSize).IsRequired();
        builder.Property(m => m.DisplayOrder).IsRequired();

        builder.HasOne(m => m.Account).WithMany(m => m.Schedules).HasForeignKey(m => m.AccountId).OnDelete(DeleteBehavior.Cascade);
    }
}