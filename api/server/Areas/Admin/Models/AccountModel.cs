namespace Coevent.Api.Areas.Admin.Models;

using Coevent.Api.Models;
using Coevent.Entities;

public class AccountModel : AuditColumnsModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public AccountType AccountType { get; set; }

    public bool IsDisabled { get; set; }

    public long OwnerId { get; set; }

    public UserModel? Owner { get; set; }

    public ICollection<CalendarModel> Calendars { get; set; } = new List<CalendarModel>();

    public ICollection<EventModel> Events { get; set; } = new List<EventModel>();

    public ICollection<ScheduleModel> Schedules { get; set; } = new List<ScheduleModel>();

    public ICollection<TraitModel> Traits { get; set; } = new List<TraitModel>();

    public ICollection<CriteriaModel> Criterias { get; set; } = new List<CriteriaModel>();

    public ICollection<SurveyModel> Surveys { get; set; } = new List<SurveyModel>();

    public ICollection<UserModel> Users { get; set; } = new List<UserModel>();

    public ICollection<RoleModel> Roles { get; set; } = new List<RoleModel>();

    public ICollection<ClaimModel> Claims { get; set; } = new List<ClaimModel>();

    public ICollection<UserClaimModel> UserClaims { get; set; } = new List<UserClaimModel>();
}
