namespace Coevent.Dal.Repositories;

using Coevent.Dal.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class BaseCrudRepository<T> : IBaseCrudRepository<T>
    where T : class
{
    #region Variables
    private readonly ILogger _logger;
    private readonly CoeventContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion

    #region Properties
    protected CoeventContext Context { get { return _context; } }

    protected IHttpContextAccessor HttpContextAccessor { get { return _httpContextAccessor; } }
    #endregion

    #region Constructors
    public BaseCrudRepository(CoeventContext context, IHttpContextAccessor httpContextAccessor, ILogger logger)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }
    #endregion

    #region Constructors
    public IEnumerable<T> FindAll()
    {
        _logger.LogDebug($"Find all '{nameof(T)}'");
        return _context.Set<T>().ToArray();
    }

    public IEnumerable<T> FindAllNoTracking()
    {
        _logger.LogDebug($"Find all '{nameof(T)}'");
        return _context.Set<T>().AsNoTracking().ToArray();
    }

    public T? Find(params object[] key)
    {
        _logger.LogDebug($"Find '{nameof(T)}'");
        return _context.Find<T>(key);
    }

    public void Add(T entity)
    {
        _context.Add(entity);
    }

    public T AddAndSave(T entity)
    {
        _logger.LogDebug($"Add '{nameof(T)}'");
        this.Add(entity);
        return this.SaveChanges(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public T UpdateAndSave(T entity)
    {
        _logger.LogDebug($"Update '{nameof(T)}'");
        this.Update(entity);
        return this.SaveChanges(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public void DeleteAndSave(T entity)
    {
        _logger.LogDebug($"Delete '{nameof(T)}'");
        this.Delete(entity);
        this.SaveChanges(entity);
    }

    public T SaveChanges(T entity)
    {
        _context.SaveChanges();
        return entity;
    }
    #endregion
}
