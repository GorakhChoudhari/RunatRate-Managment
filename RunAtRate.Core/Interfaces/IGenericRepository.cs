namespace RunAtRate.Core.Interfaces;
using System.Linq.Expressions;

public interface IGenericRepository<T> where T : class
{
    // ✅ GET: all records
    Task<IEnumerable<T>> GetAllAsync();

    // ✅ GET: single record by ID
    Task<T?> GetByIdAsync(int id);

    // ✅ POST: add new
    Task AddAsync(T entity);

    // ✅ PUT: update
    void Update(T entity);

    // ✅ DELETE
    void Delete(T entity);

    // ✅ GET with includes (for deep navigation)
    Task<T?> GetNestedIncludeAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IQueryable<T>> include);
}

