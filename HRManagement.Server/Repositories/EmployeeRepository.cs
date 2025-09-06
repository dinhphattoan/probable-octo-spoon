using HRMagnement.Server.Data;
using HRMagnement.Server.Models;
using HRManagement.Server.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Server.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            

        }
    }
}
