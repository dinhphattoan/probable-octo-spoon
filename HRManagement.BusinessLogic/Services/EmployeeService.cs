using AutoMapper;
using DataAccessLayer.Repositories;
using HRManagement.Contacts.Services;
namespace HRManagement.BussinessLogic.Services;

public sealed class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

}