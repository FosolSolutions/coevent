namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class AccountService : BaseCrudRepository<Account>, IAccountService
{
    #region Variables
    #endregion

    #region Constructors
    public AccountService(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger<AccountService> logger) : base(context, httpContextAccessor, logger)
    {
    }
    #endregion

    #region Methods
    #endregion
}
