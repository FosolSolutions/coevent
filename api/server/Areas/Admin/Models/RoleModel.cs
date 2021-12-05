using Coevent.Api.Models;

namespace Coevent.Api.Areas.Admin.Models;

/// <summary>
/// get/set -
/// </summary>
public class RoleModel : AuditColumnsModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public long AccountId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public AccountModel? Account { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<UserModel> Users { get; set; } = new List<UserModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<ClaimModel> Claims { get; set; } = new List<ClaimModel>();
}
