namespace Coevent.Entities;

public class RoleClaim : AuditColumns
{
    #region Properties
    public int RoleId { get; protected set; }

    public Role Role { get; protected set; }

    public long ClaimId { get; protected set; }

    public Claim Claim { get; protected set; }
    #endregion

    #region Constructors
    public RoleClaim(Role role, Claim claim, string createdBy) : base(createdBy)
    {
        this.Role = role ?? throw new ArgumentNullException(nameof(role));
        this.RoleId = role.Id;
        this.Claim = claim ?? throw new ArgumentNullException(nameof(claim));
        this.ClaimId = claim.Id;
    }
    #endregion
}