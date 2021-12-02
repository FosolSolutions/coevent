namespace Coevent.Api.Areas.Admin.Models;

using Coevent.Entities;

/// <summary>
/// get/set -
/// </summary>
public class OpeningModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public long Id { get; set; }

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
    public long EventId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public EventModel? Event { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public OpeningType OpeningType { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ApplyType ApplyType { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public long? SurveyId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public SurveyModel? Survey { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<OpeningCriteriaModel> OpeningCriterias { get; set; } = new List<OpeningCriteriaModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<OpeningOccurrenceModel> OpeningOccurrences { get; set; } = new List<OpeningOccurrenceModel>();
}
