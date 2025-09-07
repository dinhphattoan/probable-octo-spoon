using AutoMapper;
using HRManagement.BussinessLogic.DTOs;
using HRManagement.DataAccess.Repositories;

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

    public Task<EmployeeDto> CreateAsync(CreateEmployeeRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EmployeeDto>> GetActiveAsync(bool includeContact)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDto?> GetByIdAsync(Guid id, bool includeContact)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(UpdateEmployeeRequest request)
    {
        throw new NotImplementedException();
    }
}