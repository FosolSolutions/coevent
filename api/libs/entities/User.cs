namespace Coevent.Entities;

public class User : AuditColumns
{
    #region Properties
    public long Id { get; protected set; }

    public string Username { get; protected set; }

    public string Email { get; protected set; }

    public Guid Key { get; protected set; }

    public string DisplayName { get; protected set; }

    public string FirstName { get; protected set; }

    public string MiddleName { get; protected set; }

    public string LastName { get; protected set; }

    public bool IsDisabled { get; protected set; }

    public int FailedLogins { get; protected set; }

    public UserType UserType { get; protected set; }

    public bool IsVerified { get; protected set; }

    public DateTime? VerifiedOn { get; protected set; }

    public ICollection<UserAccount> AccountsManyToMany { get; } = new List<UserAccount>();

    public ICollection<Account> Accounts { get; } = new List<Account>();

    public ICollection<Application> Applications { get; } = new List<Application>();

    public ICollection<Participant> Participants { get; } = new List<Participant>();

    public ICollection<UserRole> RolesManyToMany { get; } = new List<UserRole>();

    public ICollection<Role> Roles { get; } = new List<Role>();

    public ICollection<UserClaim> Claims { get; } = new List<UserClaim>();

    #endregion

    #region Constructors
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