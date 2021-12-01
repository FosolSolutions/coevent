namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OpeningConfiguration : AuditColumnsConfiguration<Opening>
{
    protected override void OnConfigure(EntityTypeBuilder<Opening> builder)
    {
        builder.ToTable("Openings");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).IsRequired(false).HasMaxLength(2000);
        builder.Property(m => m.OpeningType).IsRequired();
        builder.Property(m => m.IsDisabled).IsRequired();
        builder.Property(m => m.EventId).IsRequired();
        builder.Property(m => m.DisplayOrder).IsRequired();
        builder.Property(m => m.ApplyType).IsRequired();
        builder.Property(m => m.Quantity).IsRequired();
        builder.Property(m => m.SurveyId).IsRequired(false);

        builder.HasOne(m => m.Event).WithMany(m => m.Openings).HasForeignKey(m => m.EventId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(m => m.Survey).WithMany(m => m.Openings).HasForeignKey(m => m.SurveyId).OnDelete(DeleteBehavior.ClientNoAction);
    }
}
