using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMagnement.Models
{
    public class EmployeeContact
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Foreign key to Employee - Changed from int to Guid to match Employee.Id
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        public bool IsPrimary { get; set; }         // Mark main contact method
        public string? Notes { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; set; }
        
        public Employee Employee { get; set; } = default!;

        public EmployeeContact()
        {
            Email = string.Empty;
        }
    }
}
