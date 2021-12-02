namespace Coevent.Dal.Services.Interfaces;

using Coevent.Entities;

public interface IUserService : IBaseService<User>
{
    User? FindByKey(Guid key);
    User? FindByUsername(string username);

    IEnumerable<UserClaim> GetClaims(long userId);
}
