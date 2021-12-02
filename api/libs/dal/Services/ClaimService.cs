namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class ClaimService : BaseCrudRepository<Claim>, IClaimService
{
    #region Variables
    #endregion

    #region Constructors
    public ClaimService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<ClaimService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
