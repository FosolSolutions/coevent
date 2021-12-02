namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class EventService : BaseCrudRepository<Event>, IEventService
{
    #region Variables
    #endregion

    #region Constructors
    public EventService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<EventService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
