using HRManagement.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using HRManagement.Contacts.Repositories;
using HRManagement.Models;
using HRManagement.DataAccess.Data;

namespace HRManagement.DataAccess.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IQueryable<Employee> Query(bool asNoTracking = true);
        Task<List<Employee>> GetActiveAsync(bool includeContact = false);
        Task<Employee?> GetWithContactAsync(Guid id);
    }

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context) { }

        public IQueryable<Employee> Query(bool asNoTracking = true)
        {
            var query = _dbSet.AsQueryable();
            if (asNoTracking) query = query.AsNoTracking();
            return query;
        }

        public async Task<List<Employee>> GetActiveAsync(bool includeContact = false)
        {
            var query = Query();
            if (includeContact) query = query.Include(e => e.EmployeeContact);
            return await query.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<Employee?> GetWithContactAsync(Guid id)
        {
            return await Query()
                .Include(e => e.EmployeeContact)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
