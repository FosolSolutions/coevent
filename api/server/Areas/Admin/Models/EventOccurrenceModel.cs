namespace Coevent.Api.Areas.Admin.Models;

using Coevent.Api.Models;
using Coevent.Entities;

/// <summary>
/// get/set -
/// </summary>
public class EventOccurrenceModel : AuditColumnsModel
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
    public long EventId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public EventModel? Event { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public EventStatus Status { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public DateTime StartOn { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public DateTime EndOn { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<OpeningOccurrenceModel> OpeningOccurrences { get; } = new List<OpeningOccurrenceModel>();
}
