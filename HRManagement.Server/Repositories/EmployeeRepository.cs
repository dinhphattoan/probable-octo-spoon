using HRMagnement.Server.Models;
using HRManagement.Server.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Server.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(DbContext context) : base(context)
        {
            

        }
    }
}
