namespace Coevent.Dal.Configuration;

using Coevent.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AccountConfiguration : AuditColumnsConfiguration<Account>
{
    protected override void OnConfigure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).IsRequired(false).HasMaxLength(2000);
        builder.Property(m => m.AccountType).IsRequired();
        builder.Property(m => m.IsDisabled).IsRequired();
        builder.Property(m => m.OwnerId).IsRequired();

        builder.HasOne(m => m.Owner).WithMany(m => m.OwnerAccounts).HasForeignKey(m => m.OwnerId).OnDelete(DeleteBehavior.Restrict);
    }
}
