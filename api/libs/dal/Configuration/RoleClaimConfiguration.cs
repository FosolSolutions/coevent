namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoleClaimConfiguration : AuditColumnsConfiguration<RoleClaim>
{
    protected override void OnConfigure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable("RoleClaims");

        builder.HasKey(m => new { m.RoleId, m.ClaimId });
        builder.Property(m => m.RoleId).ValueGeneratedNever();
        builder.Property(m => m.ClaimId).ValueGeneratedNever();

        builder.HasOne(m => m.Role).WithMany(m => m.ClaimsManyToMany).HasForeignKey(m => m.RoleId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(m => m.Claim).WithMany(m => m.RolesManyToMany).HasForeignKey(m => m.ClaimId).OnDelete(DeleteBehavior.Cascade);
    }
}