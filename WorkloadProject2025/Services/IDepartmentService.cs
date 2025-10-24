﻿using WorkloadProject2025.Data.Models;

namespace WorkloadProject2025.Services
{
    public interface IDepartmentService
    {
        Task<Department> AddAsync(Department department, CancellationToken cancellationToken = default);
        Task<List<Department>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Department?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
