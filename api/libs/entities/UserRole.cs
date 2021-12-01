namespace Coevent.Entities;

public class UserRole : AuditColumns
{
    #region Properties
    public long UserId { get; set; }

    public User? User { get; set; }

    public int RoleId { get; set; }

    public Role? Role { get; set; }
    #endregion

    #region Constructors
    protected UserRole()
    {
        this.User = null!;
        this.Role = null!;
    }

    public UserRole(User user, Role role, string createdBy) : base(createdBy)
    {
        this.User = user ?? throw new ArgumentNullException(nameof(user));
        this.UserId = user.Id;
        this.Role = role ?? throw new ArgumentNullException(nameof(role));
        this.RoleId = role.Id;
    }

    public UserRole(long userId, int roleId, string createdBy) : base(createdBy)
    {
        this.UserId = userId;
        this.RoleId = roleId;
    }
    #endregion
}
