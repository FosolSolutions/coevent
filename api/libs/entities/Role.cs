namespace Coevent.Entities;

public class Role : AuditColumns
{
    #region Properties
    public int Id { get; protected set; }

    public long AccountId { get; protected set; }

    public Account Account { get; protected set; }

    public string Name { get; protected set; }

    public string Description { get; protected set; }

    public bool IsDisabled { get; protected set; }

    public ICollection<UserRole> UsersManyToMany { get; } = new List<UserRole>();

    public ICollection<User> Users { get; } = new List<User>();

    public ICollection<RoleClaim> ClaimsManyToMany { get; } = new List<RoleClaim>();

    public ICollection<Claim> Claims { get; } = new List<Claim>();
    #endregion

    #region Constructors
    public Role(Account account, string name, string createdBy) : base(createdBy)
    {
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
    }
    #endregion
}