using WorkloadProject2025.Data.Models;

namespace WorkloadProject2025.Services
{
    public interface IFacultyWorkloadService
    {
        Task<List<FacultyWorkload>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<FacultyWorkload>> GetByFacultyEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<List<FacultyWorkload>> GetBySemesterAsync(string semester, int year, CancellationToken cancellationToken = default);
        Task<FacultyWorkload> AddAsync(FacultyWorkload workload, CancellationToken cancellationToken = default);
    }
}
