using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkloadProject2025.Data.Models;
using static WorkloadProject2025.Components.Pages.WorkloadPage;

namespace WorkloadProject2025.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<WorkloadCategory> WorkloadCategories { get; set; }
        public DbSet<ProgramOfStudy> ProgramsOfStudy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // School-Department relationship
            modelBuilder.Entity<Department>()
                .HasOne(d => d.School)
                .WithMany(s => s.Departments)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.Cascade);

            // Department-ProgramOfStudy relationship
            modelBuilder.Entity<ProgramOfStudy>()
                .HasOne(p => p.Department)
                .WithMany(d => d.ProgramsOfStudy)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProgramOfStudy-Course relationship
            modelBuilder.Entity<Course>()
                .HasOne(c => c.ProgramOfStudy)
                .WithMany(p => p.Courses)
                .HasForeignKey(c => c.ProgramOfStudyId)
                .OnDelete(DeleteBehavior.Cascade);

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
