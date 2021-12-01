namespace Coevent.Dal.Repositories.Interfaces;

public interface IBaseCrudRepository<T>
    where T : class
{
    IEnumerable<T> FindAll();

    IEnumerable<T> FindAllNoTracking();

    T? Find(params object[] key);

    void Add(T entity);

    T AddAndSave(T entity);

    void Update(T entity);

    T UpdateAndSave(T Entity);

    void Delete(T entity);

    void DeleteAndSave(T entity);

    T SaveChanges(T entity);
}
