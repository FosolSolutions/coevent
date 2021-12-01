namespace Coevent.Entities;

public class User : AuditColumns
{
    #region Properties
    public long Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public Guid Key { get; set; }

    public string DisplayName { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public bool IsDisabled { get; set; }

    public int FailedLogins { get; set; }

    public UserType UserType { get; set; }

    public bool IsVerified { get; set; }

    public DateTime? VerifiedOn { get; set; }

    public ICollection<UserAccount> AccountsManyToMany { get; } = new List<UserAccount>();

    public ICollection<Account> Accounts { get; } = new List<Account>();

    public ICollection<Account> OwnerAccounts { get; } = new List<Account>();

    public ICollection<Application> Applications { get; } = new List<Application>();

    public ICollection<Participant> Participants { get; } = new List<Participant>();

    public ICollection<UserRole> RolesManyToMany { get; } = new List<UserRole>();

    public ICollection<Role> Roles { get; } = new List<Role>();

    public ICollection<UserClaim> Claims { get; } = new List<UserClaim>();

    #endregion

    #region Constructors
    protected User()
    {
        this.Username = String.Empty;
        this.Email = String.Empty;
        this.DisplayName = String.Empty;
        this.FirstName = String.Empty;
        this.MiddleName = String.Empty;
        this.LastName = String.Empty;
    }

    public User(string username, string email, string firstName, string lastName, string createdBy) : base(createdBy)
    {
        this.Username = username;
        this.DisplayName = username;
        this.Email = email;
        this.FirstName = firstName;
        this.MiddleName = String.Empty;
        this.LastName = lastName;
    }
    #endregion
}
