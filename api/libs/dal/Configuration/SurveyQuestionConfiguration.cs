namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SurveyQuestionConfiguration : AuditColumnsConfiguration<SurveyQuestion>
{
    protected override void OnConfigure(EntityTypeBuilder<SurveyQuestion> builder)
    {
        builder.ToTable("SurveyQuestions");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.SurveyId).IsRequired();
        builder.Property(m => m.Question).IsRequired().HasMaxLength(2000);
        builder.Property(m => m.IsRequired).IsRequired();
        builder.Property(m => m.IsDisabled).IsRequired();
        builder.Property(m => m.DisplayOrder).IsRequired();

        builder.HasOne(m => m.Survey).WithMany(m => m.Questions).HasForeignKey(m => m.SurveyId).OnDelete(DeleteBehavior.Cascade);
    }
}