namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoleConfiguration : AuditColumnsConfiguration<Role>
{
    protected override void OnConfigure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).IsRequired().HasMaxLength(2000);
        builder.Property(m => m.AccountId).IsRequired();
        builder.Property(m => m.IsDisabled).IsRequired();

        builder.HasOne(m => m.Account).WithMany(m => m.Roles).HasForeignKey(m => m.AccountId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(m => m.Claims).WithMany(m => m.Roles).UsingEntity<RoleClaim>(
                m => m.HasOne(m => m.Claim).WithMany(m => m.RolesManyToMany).HasForeignKey(m => m.ClaimId).OnDelete(DeleteBehavior.Cascade),
                m => m.HasOne(m => m.Role).WithMany(m => m.ClaimsManyToMany).HasForeignKey(m => m.RoleId).OnDelete(DeleteBehavior.Cascade)
            );
    }
}