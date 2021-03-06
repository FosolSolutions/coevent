namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SurveyConfiguration : AuditColumnsConfiguration<Survey>
{
    protected override void OnConfigure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable("Surveys");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).IsRequired(false).HasMaxLength(2000);
        builder.Property(m => m.AccountId).IsRequired();
        builder.Property(m => m.IsDisabled).IsRequired();

        builder.HasOne(m => m.Account).WithMany(m => m.Surveys).HasForeignKey(m => m.AccountId).OnDelete(DeleteBehavior.Cascade);
    }
}