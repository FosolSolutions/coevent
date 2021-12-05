using Coevent.Api.Models;

namespace Coevent.Api.Areas.Admin.Models;

/// <summary>
/// get/set -
/// </summary>
public class UserClaimModel : AuditColumnsModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public UserModel? User { get; set; }

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
    public string Value { get; set; } = default!;
}
