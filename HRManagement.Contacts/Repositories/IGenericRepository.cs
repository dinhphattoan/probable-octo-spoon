using System.Linq.Expressions;

namespace HRManagement.Contacts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        Task DeleteByIdAsync(object id);
        void DeleteRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T?> FindFirstAsync(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQueryable();
        Task SaveChangesAsync();
    }
}
