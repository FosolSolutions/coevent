namespace Coevent.Api.Areas.Admin.Models;

using Coevent.Entities;

/// <summary>
/// get/set -
/// </summary>
public class ScheduleModel
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
    public long AccountId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public AccountModel? Account { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public TimeSpan StartOnTime { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public TimeSpan EndOnTime { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public DaysOfWeek DaysOfWeek { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public Months Months { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public RepeatType RepeatType { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public int RepeatSize { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<EventModel> Events { get; } = new List<EventModel>();
}
