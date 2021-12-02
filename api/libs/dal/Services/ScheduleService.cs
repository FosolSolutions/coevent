namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class ScheduleService : BaseCrudRepository<Schedule>, IScheduleService
{
    #region Variables
    #endregion

    #region Constructors
    public ScheduleService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<ScheduleService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
