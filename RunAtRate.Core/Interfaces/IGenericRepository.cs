namespace RunAtRate.Core.Interfaces;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;

public interface IGenericRepository<T> where T : class
{
    //  GET: all records
    Task<IEnumerable<T>> GetAllAsync();

    //  GET: single record by ID
    Task<T?> GetByIdAsync(int id);

    //  POST: add new
    Task AddAsync(T entity);

    // PUT: update
    void Update(T entity);

    //  DELETE
    void Delete(T entity);

    //  GET with includes (for deep navigation)
    Task<T?> GetNestedIncludeAsync(Expression<Func<T, bool>> predicate,Func<IQueryable<T>, IQueryable<T>> include);

  

    // Execute stored procedure returning entities
    Task<IEnumerable<T>> ExecuteStoredProcedureAsync(string spName, params SqlParameter[] parameters);

    // Execute stored procedure returning scalar (e.g., Count, Sum, etc.)
    Task<TResult> ExecuteScalarAsync<TResult>(string sql, params SqlParameter[] parameters);

    // Paging support
    Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
        int pageIndex, int pageSize, Expression<Func<T, bool>>? predicate = null);

    // Raw SQL query (if not SP but plain SELECT)
    Task<IEnumerable<T>> FromSqlAsync(string sql, params object[] parameters);
}

