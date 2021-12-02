namespace Coevent.Api.Areas.Admin.Models;

/// <summary>
/// get/set -
/// </summary>
public class SurveyQuestionModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public long SurveyId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public SurveyModel? Survey { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public string Question { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public bool IsRequired { get; set; }
}
