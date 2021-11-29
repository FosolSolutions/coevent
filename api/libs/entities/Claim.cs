namespace Coevent.Entities;

public class Claim : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public long AccountId { get; protected set; }

    public Account Account { get; protected set; }

    public string Name { get; protected set; }


    public string Description { get; protected set; }

    public ICollection<RoleClaim> RolesManyToMany { get; } = new List<RoleClaim>();

    public ICollection<Role> Roles { get; } = new List<Role>();
    #endregion

    #region Constructors
    public Claim(Account account, string name, string createdBy) : base(createdBy)
    {
        this.Account = account ?? throw new ArgumentNullException(nameof(account));
        this.AccountId = account.Id;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        this.Description = String.Empty;
    }
    #endregion
}