namespace Coevent.Entities;

public class UserClaim : AuditColumns
{
    #region Properties
    public long UserId { get; set; }

    public User? User { get; set; }

    public long AccountId { get; set; }

    public Account? Account { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }
    #endregion

    #region Constructors
    protected UserClaim()
    {
        this.Name = String.Empty;
        this.Value = String.Empty;
        this.User = null!;
        this.Account = null!;
    }

    public UserClaim(User user, Account account, string name, string value, string createdBy) : base(createdBy)
    {
        this.User = user ?? throw new ArgumentNullException(nameof(user));
        this.UserId = user.Id;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public UserClaim(long userId, long accountId, string name, string value, string createdBy) : base(createdBy)
    {
        this.UserId = userId;
        this.AccountId = accountId;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Value = value ?? throw new ArgumentNullException(nameof(value));
    }
    #endregion
}
