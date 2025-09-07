using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

//Hired Employee class

namespace HRMagnement.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }



        [Required]
        [StringLength(100)]
        public string Department { get; set; }

        [Required]
        [StringLength(100)]
        public string Position { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; } = true;

        public EmployeeContact? EmployeeContact { get; set; }
        public Employee()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Department = string.Empty;
            Position = string.Empty;
        }
    }
}
