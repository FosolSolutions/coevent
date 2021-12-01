namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class CalendarService : BaseCrudRepository<Calendar>, ICalendarService
{
    #region Variables
    #endregion

    #region Constructors
    public CalendarService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<CalendarService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
