using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace RunAtRate.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        #region CRUD

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) =>
            await _dbSet.FindAsync(id);

        public async Task AddAsync(T entity) =>
            await _dbSet.AddAsync(entity);

        public void Update(T entity) =>
            _dbSet.Update(entity);

        public void Delete(T entity) =>
            _dbSet.Remove(entity);

        #endregion

        #region Includes

        public async Task<T?> GetNestedIncludeAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IQueryable<T>> include)
        {
            IQueryable<T> query = _dbSet;
            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<T?> GetWithIncludesAsync(
            Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(predicate);
        }

        #endregion

        #region Stored Procedures / Raw SQL

        public async Task<IEnumerable<T>> ExecuteStoredProcedureAsync(
            string spName, params SqlParameter[] parameters)
        {
            var sql = (parameters != null && parameters.Any())
                ? $"EXEC {spName} {string.Join(", ", parameters.Select(p => p.ParameterName))}"
                : $"EXEC {spName}";

            return await _dbSet.FromSqlRaw(sql, parameters).ToListAsync();
        }

        public async Task<TResult> ExecuteScalarAsync<TResult>(
            string sql, params SqlParameter[] parameters)
        {
            await using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = sql;
            command.CommandType = System.Data.CommandType.Text;

            if (parameters != null)
                foreach (var param in parameters)
                    command.Parameters.Add(param);

            if (command.Connection!.State != System.Data.ConnectionState.Open)
                await command.Connection.OpenAsync();

            var result = await command.ExecuteScalarAsync();
            return (TResult)Convert.ChangeType(result, typeof(TResult));
        }

        public async Task<IEnumerable<T>> FromSqlAsync(string sql, params object[] parameters) =>
            await _dbSet.FromSqlRaw(sql, parameters).ToListAsync();

        #endregion

        #region Paging

        public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            int pageIndex, int pageSize, Expression<Func<T, bool>>? predicate = null)
        {
            var query = _dbSet.AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return (items, totalCount);
        }

        #endregion

        #region Transaction

        public async Task ExecuteInTransactionAsync(Func<Task> action)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await action();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        #endregion
    }
}
