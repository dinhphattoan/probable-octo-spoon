using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRManagement.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace HRMagnement.Models
{
    [Index(nameof(JobReferenceCode), IsUnique = true)]
    public class JobPoster
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(8000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string CompanyName { get; set; } = string.Empty;

        [StringLength(150)]
        public string? Department { get; set; }

        [StringLength(100)]
        public string? LocationCity { get; set; }

        [StringLength(100)]
        public string? LocationState { get; set; }

        [StringLength(100)]
        public string? LocationCountry { get; set; }

        [Required]
        public EmploymentType EmploymentType { get; set; } = EmploymentType.FullTime;

        [Required]
        public WorkArrangement WorkArrangement { get; set; } = WorkArrangement.Onsite;

        [Required]
        public ExperienceLevel ExperienceLevel { get; set; } = ExperienceLevel.Mid;

        [Required]
        public JobCategory Category { get; set; } = JobCategory.Engineering;

        [Precision(18, 2)]
        [DataType(DataType.Currency)]
        public decimal? SalaryMin { get; set; }

        [Precision(18, 2)]
        [DataType(DataType.Currency)]
        public decimal? SalaryMax { get; set; }

        [Required]
        public DateTimeOffset PostedAt { get; set; } = DateTimeOffset.UtcNow;

        public DateTimeOffset? ExpiresAt { get; set; }

        [NotMapped]
        public bool IsExpired => ExpiresAt.HasValue && ExpiresAt.Value < DateTimeOffset.UtcNow;

        [NotMapped]
        public bool IsActive => !IsExpired;

        [Required]
        [EmailAddress]
        [StringLength(254)]
        public string ContactEmail { get; set; } = string.Empty;

        [Phone]
        [StringLength(30)]
        public string? ContactPhone { get; set; }

        [Url]
        [StringLength(2048)]
        public string? ApplicationUrl { get; set; }

        [StringLength(50)]
        public string? JobReferenceCode { get; set; }

        [Range(1, 100000)]
        public int? MaxApplicants { get; set; }

        // Store skills as CSV for simple persistence; expose as a read-only list.
        [StringLength(2000)]
        public string? SkillsCsv { get; set; }

        [NotMapped]
        public IReadOnlyList<string> Skills =>
            string.IsNullOrWhiteSpace(SkillsCsv)
                ? Array.Empty<string>()
                : SkillsCsv.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        public void SetSkills(IEnumerable<string>? skills)
        {
            if (skills is null)
            {
                SkillsCsv = null;
                return;
            }

            var list = new List<string>();
            foreach (var s in skills)
            {
                if (!string.IsNullOrWhiteSpace(s))
                    list.Add(s.Trim());
            }

            SkillsCsv = list.Count == 0 ? null : string.Join(", ", list);
        }

        public ICollection<NewApplicant> NewApplicants { get; set; } = new List<NewApplicant>();

       
    }

}
