namespace Coevent.Entities;

public class Claim : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public long AccountId { get; set; }

    public Account? Account { get; set; }

    public string Name { get; set; }


    public string Description { get; set; }

    public ICollection<RoleClaim> RolesManyToMany { get; } = new List<RoleClaim>();

    public ICollection<Role> Roles { get; } = new List<Role>();
    #endregion

    #region Constructors
    protected Claim()
    {
        this.Name = String.Empty;
        this.Description = String.Empty;
        this.Account = null!;
    }

    public Claim(Account account, string name)
    {
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
    }

    public Claim(long accountId, string name)
    {
        this.AccountId = accountId;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
    }
    #endregion
}
