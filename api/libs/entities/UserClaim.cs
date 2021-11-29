namespace Coevent.Entities;

public class UserClaim : AuditColumns
{
    #region Properties
    public long UserId { get; protected set; }

    public User User { get; protected set; }

    public long AccountId { get; protected set; }

    public Account Account { get; protected set; }

    public string Name { get; protected set; }

    public string Value { get; protected set; }
    #endregion

    #region Constructos
    public UserClaim(User user, Account account, string name, string value, string createdBy) : base(createdBy)
    {
        this.User = user ?? throw new ArgumentNullException(nameof(user));
        this.UserId = user.Id;
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Value = value ?? throw new ArgumentNullException(nameof(value));
    }
    #endregion
}