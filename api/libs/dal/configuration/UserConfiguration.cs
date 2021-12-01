namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : AuditColumnsConfiguration<User>
{
    protected override void OnConfigure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Username).IsRequired().HasMaxLength(50);
        builder.Property(m => m.Email).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Key).IsRequired();
        builder.Property(m => m.DisplayName).IsRequired().HasMaxLength(50);
        builder.Property(m => m.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(m => m.MiddleName).IsRequired(false).HasMaxLength(50);
        builder.Property(m => m.LastName).IsRequired().HasMaxLength(50);
        builder.Property(m => m.FailedLogins).IsRequired();
        builder.Property(m => m.UserType).IsRequired();
        builder.Property(m => m.VerifiedOn).IsRequired(false).HasColumnType("DATETIME2");
        builder.Property(m => m.IsVerified).IsRequired();
        builder.Property(m => m.IsDisabled).IsRequired();

        builder.HasMany(m => m.Roles).WithMany(m => m.Users).UsingEntity<UserRole>(
                m => m.HasOne(m => m.Role).WithMany(m => m.UsersManyToMany).HasForeignKey(m => m.RoleId).OnDelete(DeleteBehavior.Cascade),
                m => m.HasOne(m => m.User).WithMany(m => m.RolesManyToMany).HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(m => m.Accounts).WithMany(m => m.Users).UsingEntity<UserAccount>(
                m => m.HasOne(m => m.Account).WithMany(m => m.UsersManyToMany).HasForeignKey(m => m.AccountId).OnDelete(DeleteBehavior.Cascade),
                m => m.HasOne(m => m.User).WithMany(m => m.AccountsManyToMany).HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.Cascade)
            );

        builder.HasIndex(m => m.Username).IsUnique(true);
        builder.HasIndex(m => m.Email).IsUnique(true);
        builder.HasIndex(m => m.Key).IsUnique(true);
        builder.HasIndex(m => m.DisplayName).IsUnique(true);
    }
}
