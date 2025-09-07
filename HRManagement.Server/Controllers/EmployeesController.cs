using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.DTOs;
using HRManagement.Contacts.Services;

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
