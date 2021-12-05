namespace Coevent.Api.Areas.Admin.Models;

using Coevent.Api.Models;
using Coevent.Entities;

/// <summary>
/// get/set -
/// </summary>
public class CriteriaTraitModel : AuditColumnsModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public long CriteriaId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public CriteriaModel? Criteria { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public long TraitId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public TraitModel? Trait { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public Formula Formula { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public string Value { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public bool IsRequired { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public bool IsDisabled { get; set; }
}
