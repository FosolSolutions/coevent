namespace Coevent.Api.Models;

/// <summary>
/// get/set -
/// </summary>
public abstract class AuditColumnsModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public string? RowVersion { get; set; }
}
