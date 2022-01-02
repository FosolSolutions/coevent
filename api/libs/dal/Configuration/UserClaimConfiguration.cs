namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserClaimConfiguration : AuditColumnsConfiguration<UserClaim>
{
    protected override void OnConfigure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("UserClaims");

        builder.HasKey(m => new { m.UserId, m.AccountId, m.Name });
        builder.Property(m => m.UserId).ValueGeneratedNever();
        builder.Property(m => m.AccountId).ValueGeneratedNever();
        builder.Property(m => m.Name).HasMaxLength(50).ValueGeneratedNever();
        builder.Property(m => m.Value).IsRequired().HasMaxLength(100);

        builder.HasOne(m => m.User).WithMany(m => m.Claims).HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(m => m.Account).WithMany(m => m.UserClaims).HasForeignKey(m => m.AccountId).OnDelete(DeleteBehavior.Cascade);
    }
}