namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class UserService : BaseCrudRepository<User>, IUserService
{
    #region Variables
    #endregion

    #region Constructors
    public UserService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<UserService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
