namespace Coevent.Api.Areas.Admin.Models;

using Coevent.Api.Models;
using Coevent.Entities;

/// <summary>
/// AccountModel class, provides a model for an account.
/// </summary>
public class AccountModel : AuditColumnsModel
{
    /// <summary>
    /// get/set - Primary key.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// get/set - Name to identify the account.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// get/set - Description of the account.
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// get/set - Account type [Free, Subscriber].
    /// </summary>
    public AccountType AccountType { get; set; }

    /// <summary>
    /// get/set - Whether this account has been disabled.
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// get/set - Foreign key to the owner user account.
    /// </summary>
    public long OwnerId { get; set; } = default!;

    /// <summary>
    /// get/set - The owner user account.
    /// </summary>
    public UserModel? Owner { get; set; } = default!;

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<CalendarModel> Calendars { get; set; } = new List<CalendarModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<EventModel> Events { get; set; } = new List<EventModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<ScheduleModel> Schedules { get; set; } = new List<ScheduleModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<TraitModel> Traits { get; set; } = new List<TraitModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<CriteriaModel> Criterias { get; set; } = new List<CriteriaModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<SurveyModel> Surveys { get; set; } = new List<SurveyModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<UserModel> Users { get; set; } = new List<UserModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<RoleModel> Roles { get; set; } = new List<RoleModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<ClaimModel> Claims { get; set; } = new List<ClaimModel>();

    /// <summary>
    /// get/set -
    /// </summary>
    public ICollection<UserClaimModel> UserClaims { get; set; } = new List<UserClaimModel>();
}
