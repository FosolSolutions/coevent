namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserRoleConfiguration : AuditColumnsConfiguration<UserRole>
{
    protected override void OnConfigure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");

        builder.HasKey(m => new { m.UserId, m.RoleId });
        builder.Property(m => m.UserId).ValueGeneratedNever();
        builder.Property(m => m.RoleId).ValueGeneratedNever();

        builder.HasOne(m => m.User).WithMany(m => m.RolesManyToMany).HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(m => m.Role).WithMany(m => m.UsersManyToMany).HasForeignKey(m => m.RoleId).OnDelete(DeleteBehavior.Cascade);
    }
}