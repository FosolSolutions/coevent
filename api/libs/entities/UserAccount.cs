namespace Coevent.Entities;

public class UserAccount : AuditColumns
{
    #region Properties
    public long UserId { get; set; }

    public User? User { get; set; }

    public long AccountId { get; set; }

    public Account? Account { get; set; }
    #endregion

    #region Constructors
    protected UserAccount()
    {
        this.User = null!;
        this.Account = null!;
    }

    public UserAccount(User user, Account account, string createdBy) : base(createdBy)
    {
        this.User = user ?? throw new ArgumentNullException(nameof(user));
        this.UserId = user.Id;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
    }

    public UserAccount(long userId, long accountId, string createdBy) : base(createdBy)
    {
        this.UserId = userId;
        this.AccountId = accountId;
    }
    #endregion
}
