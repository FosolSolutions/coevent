namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class SurveyService : BaseCrudRepository<Survey>, ISurveyService
{
    #region Variables
    #endregion

    #region Constructors
    public SurveyService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<SurveyService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
