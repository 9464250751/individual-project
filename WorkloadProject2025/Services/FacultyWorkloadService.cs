using Microsoft.EntityFrameworkCore;
using WorkloadProject2025.Data;
using WorkloadProject2025.Data.Models;

namespace WorkloadProject2025.Services
{
    public class FacultyWorkloadService : IFacultyWorkloadService
    {
        private readonly ApplicationDbContext _context;

        public FacultyWorkloadService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FacultyWorkload>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.FacultyWorkloads
                .Include(fw => fw.Faculty)
                    .ThenInclude(f => f.Department)
                .Include(fw => fw.Course)
                    .ThenInclude(c => c.ProgramOfStudy)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<FacultyWorkload>> GetByFacultyEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.FacultyWorkloads
                .Include(fw => fw.Faculty)
                    .ThenInclude(f => f.Department)
                .Include(fw => fw.Course)
                    .ThenInclude(c => c.ProgramOfStudy)
                .Where(fw => fw.FacultyEmail == email)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<FacultyWorkload>> GetBySemesterAsync(string semester, int year, CancellationToken cancellationToken = default)
        {
            return await _context.FacultyWorkloads
                .Include(fw => fw.Faculty)
                    .ThenInclude(f => f.Department)
                .Include(fw => fw.Course)
                    .ThenInclude(c => c.ProgramOfStudy)
                .Where(fw => fw.Semester == semester && fw.Year == year)
                .ToListAsync(cancellationToken);
        }

        public async Task<FacultyWorkload> AddAsync(FacultyWorkload workload, CancellationToken cancellationToken = default)
        {
            if (workload == null)
                throw new ArgumentNullException(nameof(workload));

            _context.FacultyWorkloads.Add(workload);
            await _context.SaveChangesAsync(cancellationToken);

            return workload;
        }
    }
}
