namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserAccountConfiguration : AuditColumnsConfiguration<UserAccount>
{
    protected override void OnConfigure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable("UserAccounts");

        builder.HasKey(m => new { m.UserId, m.AccountId });
        builder.Property(m => m.UserId).ValueGeneratedNever();
        builder.Property(m => m.AccountId).ValueGeneratedNever();

        builder.HasOne(m => m.User).WithMany(m => m.AccountsManyToMany).HasForeignKey(m => m.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}