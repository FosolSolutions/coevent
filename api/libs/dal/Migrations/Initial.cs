using Coevent.Core.Encryption;
using Coevent.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coevent.Dal.Migrations;

public partial class Initial : SeedMigration
{
    private readonly HashPassword _hashPassword = new();

    public override void InsertData(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            "Users",
            new string[] {
                nameof(User.Id),
                nameof(User.Username),
                nameof(User.Email),
                nameof(User.Key),
                nameof(User.Password),
                nameof(User.DisplayName),
                nameof(User.FirstName),
                nameof(User.MiddleName),
                nameof(User.LastName),
                nameof(User.IsDisabled),
                nameof(User.FailedLogins),
                nameof(User.UserType),
                nameof(User.IsVerified),
                nameof(User.VerifiedOn),
                nameof(User.CreatedBy),
                nameof(User.UpdatedBy)
                },
            new object?[] {
                 1,
                 "admin",
                 "admin@test.com",
                 "24e8ae15-848f-44ee-8a79-e014f89c538e",
                 _hashPassword.Hash(FactorySettings.DefaultPassword, FactorySettings.SaltLength),
                 "Administrator",
                 "System",
                 "",
                 "Administrator",
                 false,
                 0,
                 (int)UserType.User,
                 false,
                 null,
                 "seed",
                 "seed"
                 }
            );

        migrationBuilder.InsertData(
            "Accounts",
            new string[] {
                nameof(Account.Id),
                nameof(Account.Name),
                nameof(Account.Description),
                nameof(Account.AccountType),
                nameof(Account.IsDisabled),
                nameof(Account.OwnerId),
                nameof(Account.CreatedBy),
                nameof(Account.UpdatedBy)
                },
            new object?[] {
                1,
                "Coevent",
                "",
                (int)AccountType.Free,
                false,
                1,
                "seed",
                "seed"
             }
        );
    }
}


