namespace Coevent.Api.Areas.Admin.Models;

/// <summary>
/// get/set -
/// </summary>
public class OpeningCriteriaModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public long OpeningId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public OpeningModel? Opening { get; set; }

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
}
