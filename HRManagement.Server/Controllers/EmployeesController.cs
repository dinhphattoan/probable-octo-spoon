using HRManagement.BussinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMagnement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

    }
}
