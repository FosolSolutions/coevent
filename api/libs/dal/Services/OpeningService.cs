namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class OpeningService : BaseCrudRepository<Opening>, IOpeningService
{
    #region Variables
    #endregion

    #region Constructors
    public OpeningService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<OpeningService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
