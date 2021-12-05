using Coevent.Api.Models;

namespace Coevent.Api.Areas.Admin.Models;

/// <summary>
/// get/set -
/// </summary>
public class ClaimModel : AuditColumnsModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public long Id { get; set; }

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
    public ICollection<RoleModel> Roles { get; } = new List<RoleModel>();
}
