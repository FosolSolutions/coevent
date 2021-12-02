namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class RoleService : BaseCrudRepository<Role>, IRoleService
{
    #region Variables
    #endregion

    #region Constructors
    public RoleService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<RoleService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
