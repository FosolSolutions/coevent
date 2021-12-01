namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CalendarEventConfiguration : AuditColumnsConfiguration<CalendarEvent>
{
    protected override void OnConfigure(EntityTypeBuilder<CalendarEvent> builder)
    {
        builder.ToTable("CalendarEvents");

        builder.HasKey(m => new { m.CalendarId, m.EventId });
        builder.Property(m => m.CalendarId).ValueGeneratedNever();
        builder.Property(m => m.EventId).ValueGeneratedNever();

        builder.HasOne(m => m.Calendar).WithMany(m => m.EventsManyToMany).HasForeignKey(m => m.CalendarId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(m => m.Event).WithMany(m => m.CalendarsManyToMany).HasForeignKey(m => m.EventId).OnDelete(DeleteBehavior.ClientNoAction);
    }
}
