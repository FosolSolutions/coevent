namespace Coevent.Api.Areas.Admin.Models;

using Coevent.Entities;

/// <summary>
/// get/set -
/// </summary>
public class EventModel
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
    public EventType EventType { get; set; }

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
    public long? ScheduleId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ScheduleModel? Schedule { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<CalendarModel> Calendars { get; set; } = new List<CalendarModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<EventOccurrenceModel> Occurrences { get; set; } = new List<EventOccurrenceModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<OpeningModel> Openings { get; set; } = new List<OpeningModel>();
}
