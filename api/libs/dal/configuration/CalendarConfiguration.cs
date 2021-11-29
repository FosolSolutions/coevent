namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CalendarConfiguration : AuditColumnsConfiguration<Calendar>
{
    protected override void OnConfigure(EntityTypeBuilder<Calendar> builder)
    {
        builder.ToTable("Calendars");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).IsRequired(false).HasMaxLength(2000);
        builder.Property(m => m.CalendarType).IsRequired();
        builder.Property(m => m.IsDisabled).IsRequired();
        builder.Property(m => m.AccountId).IsRequired();
        builder.Property(m => m.Status).IsRequired();

        builder.HasOne(m => m.Account).WithMany(m => m.Calendars).HasForeignKey(m => m.AccountId).OnDelete(DeleteBehavior.Cascade);
    }
}