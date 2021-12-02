namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class CriteriaService : BaseCrudRepository<Criteria>, ICriteriaService
{
    #region Variables
    #endregion

    #region Constructors
    public CriteriaService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<CriteriaService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
