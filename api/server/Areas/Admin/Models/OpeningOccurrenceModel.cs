namespace Coevent.Api.Areas.Admin.Models;

using Coevent.Api.Models;
using Coevent.Entities;

/// <summary>
/// get/set -
/// </summary>
public class OpeningOccurrenceModel : AuditColumnsModel
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
    public long EventOccurrenceId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public EventOccurrenceModel? EventOccurrence { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public OpeningStatus Status { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<ApplicationModel> Applications { get; set; } = new List<ApplicationModel>();
}
