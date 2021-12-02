namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class ApplicationService : BaseCrudRepository<Application>, IApplicationService
{
    #region Variables
    #endregion

    #region Constructors
    public ApplicationService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<ApplicationService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
