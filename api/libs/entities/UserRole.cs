namespace Coevent.Entities;

public class UserRole : AuditColumns
{
    #region Properties
    public long UserId { get; protected set; }

    public User User { get; protected set; }

    public int RoleId { get; protected set; }

    public Role Role { get; protected set; }
    #endregion

    #region Constructors
    public UserRole(User user, Role role, string createdBy) : base(createdBy)
    {
        this.User = user ?? throw new ArgumentNullException(nameof(user));
        this.UserId = user.Id;
        this.Role = role ?? throw new ArgumentNullException(nameof(role));
        this.RoleId = role.Id;
    }
    #endregion
}