namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class TraitService : BaseCrudRepository<Trait>, ITraitService
{
    #region Variables
    #endregion

    #region Constructors
    public TraitService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<TraitService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
