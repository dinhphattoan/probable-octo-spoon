using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMagnement.Server.Models
{
    public class NewApplicant
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        [Required]
        public Guid JobPosterId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Position applied for is required")]
        [StringLength(100)]
        public string PositionAppliedFor { get; set; }

        [Required(ErrorMessage = "Resume is required")]
        public byte[] Resume { get; set; }

        public string? CoverLetter { get; set; }

        [Required]
        public DateTime DateApplied { get; set; }
        //Reference to JobPoster
        public JobPoster? JobPoster { get; set; }
        public NewApplicant()
        {
            Name = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            PositionAppliedFor = string.Empty;
            Resume = Array.Empty<byte>();
            DateApplied = DateTime.UtcNow;
        }
    }
}
