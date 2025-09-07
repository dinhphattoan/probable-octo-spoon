using HRManagement.Contacts.Repositories;
using HRManagement.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace HRManagement.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;


        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public virtual async Task<T?> GetByIdAsync(object id) => await _dbSet.FindAsync(id);
        public virtual async Task<T> AddAsync(T entity) { await _dbSet.AddAsync(entity); return entity; }
        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities) { await _dbSet.AddRangeAsync(entities); return entities; }
        public virtual T Update(T entity) { _dbSet.Update(entity); return entity; }
        public virtual void UpdateRange(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);
        public virtual void Delete(T entity) => _dbSet.Remove(entity);
        public virtual async Task DeleteByIdAsync(object id) { var entity = await GetByIdAsync(id); if (entity != null) Delete(entity); }
        public virtual void DeleteRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();
        public virtual async Task<T?> FindFirstAsync(Expression<Func<T, bool>> predicate) => await _dbSet.FirstOrDefaultAsync(predicate);
        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) => await _dbSet.AnyAsync(predicate);
        public virtual async Task<int> CountAsync() => await _dbSet.CountAsync();
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate) => await _dbSet.CountAsync(predicate);
        public virtual IQueryable<T> GetQueryable() => _dbSet.AsQueryable();
        public virtual async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
