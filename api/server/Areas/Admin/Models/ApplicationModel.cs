namespace Coevent.Api.Areas.Admin.Models;

using Coevent.Entities;

/// <summary>
/// get/set -
/// </summary>
public class ApplicationModel
{
    /// <summary>
    /// get/set -
    /// </summary>
    public long Id { get; set; }

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
    public long OpeningId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public long EventOccurrenceId { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public OpeningOccurrenceModel? OpeningOccurrence { get; set; }

    /// <summary>
    /// get/set -
    /// </summary>
    public ApplicationStatus Status { get; set; }
}
