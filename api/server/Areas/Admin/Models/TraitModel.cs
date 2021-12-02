namespace Coevent.Api.Areas.Admin.Models;

/// <summary>
/// get/set -
/// </summary>
public class TraitModel
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
    public bool IsDisabled { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<CriteriaTraitModel> CriteriaTraits { get; set; } = new List<CriteriaTraitModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<OpeningCriteriaModel> OpeningCriterias { get; set; } = new List<OpeningCriteriaModel>();
}
