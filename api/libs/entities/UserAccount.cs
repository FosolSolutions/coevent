namespace Coevent.Entities;

public class UserAccount : AuditColumns
{
    #region Properties
    public long UserId { get; protected set; }

    public User User { get; protected set; }

    public long AccountId { get; protected set; }

    public Account Account { get; protected set; }
    #endregion

    #region Constructors
    public UserAccount(User user, Account account, string createdBy) : base(createdBy)
    {
        this.User = user ?? throw new ArgumentNullException(nameof(user));
        this.UserId = user.Id;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
    }
    #endregion
}