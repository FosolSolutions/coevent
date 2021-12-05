namespace Coevent.Api.Areas.Admin.Models;

using Coevent.Api.Models;
using Coevent.Entities;

/// <summary>
/// get/set -
/// </summary>
public class CalendarModel : AuditColumnsModel
{

    /// <summary>
    /// get/set -
    /// </summary>
    public int Id { get; set; }

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
    public CalendarType CalendarType { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public bool IsDisabled { get; set; }

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
    public CalendarStatus Status { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<ParticipantModel> Participants { get; set; } = new List<ParticipantModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<EventModel> Events { get; set; } = new List<EventModel>();
}
