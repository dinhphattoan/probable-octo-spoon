using AutoMapper;
using HRManagement.BussinessLogic.DTOs;
using HRManagement.DataAccess.Repositories;
using HRManagement.Models;

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

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        var employees = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    public async Task<IEnumerable<EmployeeDto>> GetActiveAsync(bool includeContact)
    {
        var employees = await _repo.GetActiveAsync(includeContact);
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    public async Task<EmployeeDto?> GetByIdAsync(Guid id, bool includeContact)
    {
        Employee? employee;
        
        if (includeContact)
        {
            employee = await _repo.GetWithContactAsync(id);
        }
        else
        {
            employee = await _repo.GetByIdAsync(id);
        }

        return employee != null ? _mapper.Map<EmployeeDto>(employee) : null;
    }

    public async Task<EmployeeDto> CreateAsync(CreateEmployeeRequest request)
    {
        var employee = _mapper.Map<Employee>(request);
        
        // If contact information is provided, set the EmployeeId
        if (employee.EmployeeContact != null)
        {
            employee.EmployeeContact.EmployeeId = employee.Id;
        }

        var createdEmployee = await _repo.AddAsync(employee);
        await _repo.SaveChangesAsync();

        return _mapper.Map<EmployeeDto>(createdEmployee);
    }

    public async Task<bool> UpdateAsync(UpdateEmployeeRequest request)
    {
        var existingEmployee = await _repo.GetWithContactAsync(request.Id);
        if (existingEmployee == null)
        {
            return false;
        }

        // Map the update request to the existing employee
        _mapper.Map(request, existingEmployee);
        
        // Handle contact updates
        if (request.Contact != null)
        {
            if (existingEmployee.EmployeeContact != null)
            {
                // Update existing contact
                _mapper.Map(request.Contact, existingEmployee.EmployeeContact);
                existingEmployee.EmployeeContact.UpdatedAt = DateTimeOffset.UtcNow;
            }
            else
            {
                // Create new contact
                existingEmployee.EmployeeContact = _mapper.Map<EmployeeContact>(request.Contact);
                existingEmployee.EmployeeContact.EmployeeId = existingEmployee.Id;
            }
        }

        _repo.Update(existingEmployee);
        await _repo.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var employee = await _repo.GetByIdAsync(id);
        if (employee == null)
        {
            return false;
        }

        // Soft delete by setting IsActive to false
        employee.IsActive = false;
        _repo.Update(employee);
        await _repo.SaveChangesAsync();
        
        return true;
    }
}