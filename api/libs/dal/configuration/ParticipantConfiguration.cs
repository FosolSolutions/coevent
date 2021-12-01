namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ParticipantConfiguration : AuditColumnsConfiguration<Participant>
{
    protected override void OnConfigure(EntityTypeBuilder<Participant> builder)
    {
        builder.ToTable("Participants");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.UserId).IsRequired();
        builder.Property(m => m.CalendarId).IsRequired();
        builder.Property(m => m.TTL).IsRequired();
        builder.Property(m => m.StartOn).IsRequired(false).HasColumnType("DATETIME2");
        builder.Property(m => m.EndOn).IsRequired(false).HasColumnType("DATETIME2");

        builder.HasOne(m => m.User).WithMany(m => m.Participants).HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(m => m.Calendar).WithMany(m => m.Participants).HasForeignKey(m => m.CalendarId).OnDelete(DeleteBehavior.Restrict);
    }
}
