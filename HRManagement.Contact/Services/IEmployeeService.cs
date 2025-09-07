using BusinessLogicLayer.DTOs;

namespace HRManagement.Contacts.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllAsync();
    Task<IEnumerable<EmployeeDto>> GetActiveAsync(bool includeContact);
    Task<EmployeeDto?> GetByIdAsync(Guid id, bool includeContact);
    Task<EmployeeDto> CreateAsync(CreateEmployeeRequest request);
    Task<bool> UpdateAsync(UpdateEmployeeRequest request);
    Task<bool> DeleteAsync(Guid id);
}