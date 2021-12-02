namespace Coevent.Dal.Services;

using Coevent.Entities;
using Coevent.Dal.Repositories;
using Coevent.Dal.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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
    public User? FindByKey(Guid key)
    {
        return this.Context.Users.FirstOrDefault(u => u.Key == key);
    }

    public User? FindByUsername(string username)
    {
        return this.Context.Users.FirstOrDefault(u => u.Username == username);
    }

    public IEnumerable<UserClaim> GetClaims(long userId)
    {
        var user = this.Context.Users.Include(u => u.Claims).FirstOrDefault(u => u.Id == userId);
        return user?.Claims.ToArray() ?? Array.Empty<UserClaim>();
    }
    #endregion
}
