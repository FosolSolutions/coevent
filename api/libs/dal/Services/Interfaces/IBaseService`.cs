namespace Coevent.Dal.Services.Interfaces;

using Coevent.Dal.Repositories.Interfaces;
using Coevent.Entities;

public interface IBaseService<T> : IBaseCrudRepository<Account>
    where T : class
{

}
