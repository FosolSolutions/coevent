namespace Coevent.Entities;

public class Role : AuditColumns
{
    #region Properties
    public int Id { get; set; }

    public long AccountId { get; set; }

    public Account? Account { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsDisabled { get; set; }

    public ICollection<UserRole> UsersManyToMany { get; } = new List<UserRole>();

    public ICollection<User> Users { get; } = new List<User>();

    public ICollection<RoleClaim> ClaimsManyToMany { get; } = new List<RoleClaim>();

    public ICollection<Claim> Claims { get; } = new List<Claim>();
    #endregion

    #region Constructors
    protected Role()
    {
        this.Name = String.Empty;
        this.Description = String.Empty;
        this.Account = null!;
    }

    public Role(Account account, string name)
    {
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
    }

    public Role(long accountId, string name)
    {
        this.AccountId = accountId;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
    }
    #endregion
}
