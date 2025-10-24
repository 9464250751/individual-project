﻿using WorkloadProject2025.Data.Models;

namespace WorkloadProject2025.Services
{
    public interface ISchoolService
    {
        Task<School> AddAsync(School school, CancellationToken cancellationToken = default);
        Task<List<School>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<School?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
