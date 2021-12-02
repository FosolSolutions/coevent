namespace Coevent.Api.Areas.Admin.Models;

/// <summary>
/// get/set -
/// </summary>
public class ParticipantModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public int CalendarId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public CalendarModel? Calendar { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public UserModel? User { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public long TTL { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public DateTime? StartOn { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public DateTime? EndOn { get; set; }
}
