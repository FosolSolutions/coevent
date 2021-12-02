namespace Coevent.Api.Areas.Admin.Models;

using Coevent.Entities;

/// <summary>
/// get/set -
/// </summary>
public class UserModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public string Username { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public Guid Key { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public string DisplayName { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public string MiddleName { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public int FailedLogins { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public UserType UserType { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public bool IsVerified { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public DateTime? VerifiedOn { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<AccountModel> Accounts { get; set; } = new List<AccountModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<AccountModel> OwnerAccounts { get; set; } = new List<AccountModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<ApplicationModel> Applications { get; set; } = new List<ApplicationModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<ParticipantModel> Participants { get; set; } = new List<ParticipantModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<RoleModel> Roles { get; set; } = new List<RoleModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<UserClaimModel> Claims { get; set; } = new List<UserClaimModel>();
}
