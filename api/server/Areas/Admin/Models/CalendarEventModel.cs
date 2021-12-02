namespace Coevent.Api.Areas.Admin.Models;

/// <summary>
/// get/set -
/// </summary>
public class CalendarEventModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public int CalendarId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public CalendarModel Calendar { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public long EventId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public EventModel Event { get; set; } = default!;
}
