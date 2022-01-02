namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ClaimConfiguration : AuditColumnsConfiguration<Claim>
{
    protected override void OnConfigure(EntityTypeBuilder<Claim> builder)
    {
        builder.ToTable("Claims");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.AccountId).IsRequired();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Description).IsRequired(false).HasMaxLength(2000);

        builder.HasOne(m => m.Account).WithMany(m => m.Claims).HasForeignKey(m => m.AccountId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(m => new { m.AccountId, m.Name }).IsUnique(true);
    }
}
