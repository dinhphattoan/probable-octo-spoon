using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BussinessLogic.DTOs
{
    public sealed record EmployeeDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Department,
    string Position,
    DateTime HireDate,
    decimal Salary,
    bool IsActive,
    EmployeeContactDto? Contact);

    public sealed record EmployeeContactDto(
        Guid Id,
        string Email,
        string? PhoneNumber,
        bool IsPrimary,
        string? Notes);

    public sealed record CreateEmployeeRequest(
        string FirstName,
        string LastName,
        string Department,
        string Position,
        DateTime HireDate,
        decimal Salary,
        CreateEmployeeContactRequest? Contact);

    public sealed record CreateEmployeeContactRequest(
        string Email,
        string? PhoneNumber,
        bool IsPrimary,
        string? Notes);

    public sealed record UpdateEmployeeRequest(
        Guid Id,
        string FirstName,
        string LastName,
        string Department,
        string Position,
        DateTime HireDate,
        decimal Salary,
        bool IsActive,
        UpdateEmployeeContactRequest? Contact);

    public sealed record UpdateEmployeeContactRequest(
        string Email,
        string? PhoneNumber,
        bool IsPrimary,
        string? Notes);
}
