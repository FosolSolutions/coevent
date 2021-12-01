namespace Coevent.Dal.Services.Interfaces;

using Coevent.Dal.Repositories.Interfaces;

public interface IBaseService<T> : IBaseCrudRepository<T>
    where T : class
{

}
