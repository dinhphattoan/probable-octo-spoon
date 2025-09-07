using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMagnement.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMagnement.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; } = default!;
        public DbSet<JobPoster> JobPoster { get; set; } = default!;

        public DbSet<NewApplicant> NewApplicant { get; set; } = default!;
        public DbSet<EmployeeContact> EmployeeContact { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configuration can go here
            // Plan:
            // - Remove generic type arguments from HasMany and HasForeignKey on the JobPoster->NewApplicant relationship.
            // - Keep lambda expressions for navigation and FK property.
            // - Retain cascade delete behavior.

            // Fixed mapping line
            modelBuilder.Entity<JobPoster>()
                .HasMany(p => p.NewApplicants)
                .WithOne(p => p.JobPoster)
                .HasForeignKey(p => p.JobPosterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>().HasOne<EmployeeContact>(p=>p.EmployeeContact).WithOne(p=>p.Employee).HasForeignKey<EmployeeContact>(p=>p.EmployeeId).OnDelete(DeleteBehavior.Cascade);  

            modelBuilder.Entity<EmployeeContact>()
                .HasIndex(e => e.Email)
                .IsUnique();
  
        }
    }
}
