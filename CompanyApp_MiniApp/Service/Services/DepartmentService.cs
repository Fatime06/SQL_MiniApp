using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IEmployeeRepository _employeeRepo;
        public DepartmentService()
        {
            _departmentRepo = new DepartmentRepository();
            _employeeRepo = new EmployeeRepository();

        }
        public async Task CreateAsync(Department department)
        {
            await _departmentRepo.CreateAsync(department);
        }

        public async Task DeleteAsync(int id)
        {
            await _departmentRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _departmentRepo.GetAllAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _departmentRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Department>> SearchAsync(string name)
        {
            return await _departmentRepo.SearchAsync(name);
        }

        public Task UpdateDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
