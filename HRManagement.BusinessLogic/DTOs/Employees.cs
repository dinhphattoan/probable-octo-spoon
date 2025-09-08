using System;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
        string FirstName,
        
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters")]
        string LastName,
        
        [Required(ErrorMessage = "Department is required")]
        [StringLength(100, ErrorMessage = "Department cannot exceed 100 characters")]
        string Department,
        
        [Required(ErrorMessage = "Position is required")]
        [StringLength(100, ErrorMessage = "Position cannot exceed 100 characters")]
        string Position,
        
        [Required(ErrorMessage = "Hire date is required")]
        DateTime HireDate,
        
        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value")]
        decimal Salary,
        
        CreateEmployeeContactRequest? Contact);

    public sealed record CreateEmployeeContactRequest(
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        string Email,
        
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        string? PhoneNumber,
        
        bool IsPrimary,
        string? Notes);

    public sealed record UpdateEmployeeRequest(
        [Required]
        Guid Id,
        
        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
        string FirstName,
        
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters")]
        string LastName,
        
        [Required(ErrorMessage = "Department is required")]
        [StringLength(100, ErrorMessage = "Department cannot exceed 100 characters")]
        string Department,
        
        [Required(ErrorMessage = "Position is required")]
        [StringLength(100, ErrorMessage = "Position cannot exceed 100 characters")]
        string Position,
        
        [Required(ErrorMessage = "Hire date is required")]
        DateTime HireDate,
        
        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value")]
        decimal Salary,
        
        bool IsActive,
        UpdateEmployeeContactRequest? Contact);

    public sealed record UpdateEmployeeContactRequest(
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        string Email,
        
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        string? PhoneNumber,
        
        bool IsPrimary,
        string? Notes);
}
