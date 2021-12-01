namespace Coevent.Entities;

public class RoleClaim : AuditColumns
{
    #region Properties
    public int RoleId { get; set; }

    public Role? Role { get; set; }

    public long ClaimId { get; set; }

    public Claim? Claim { get; set; }
    #endregion

    #region Constructors
    protected RoleClaim()
    {
        this.Role = null!;
        this.Claim = null!;
    }

    public RoleClaim(Role role, Claim claim, string createdBy) : base(createdBy)
    {
        this.Role = role ?? throw new ArgumentNullException(nameof(role));
        this.RoleId = role.Id;
        this.Claim = claim ?? throw new ArgumentNullException(nameof(claim));
        this.ClaimId = claim.Id;
    }

    public RoleClaim(int roleId, long claimId, string createdBy) : base(createdBy)
    {
        this.RoleId = roleId;
        this.ClaimId = claimId;
    }
    #endregion
}
