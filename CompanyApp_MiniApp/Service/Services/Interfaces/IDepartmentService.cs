using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task CreateAsync(Department department);
        Task DeleteAsync(int id);
        Task<Department> GetByIdAsync(int id);
        Task<IEnumerable<Department>> GetAllAsync();
        Task UpdateDepartmentAsync(int Id,Department department);
        Task<IEnumerable<Department>> SearchAsync(string name);
    }
}

