using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetAllEmployeesByAgeAsync(int age)
        {
            return await _dbContext.employees.Include(m=>m.Department).Where(m=>m.Age==age).ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbContext.employees.CountAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentIdAsync(int departmentId)
        {
            return await _dbContext.employees.Where(m=>m.Department.Id==departmentId).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentNameAsync(string departmentName)
        {
            return await _dbContext.employees.Where(m=>m.Department.Name.ToLower().Trim()==departmentName.ToLower().Trim()).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SearchByNameOrSurnameAsync(string nameOrSurname)
        {
            return await _dbContext.employees.Where(m=>m.Name.ToLower().Trim().Contains(nameOrSurname.ToLower().Trim()) || m.Surname.ToLower().Trim().Contains(nameOrSurname.ToLower().Trim())).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SortEmployeesByAgeAsync(string sort)
        {
            if (sort?.ToLower().Trim() == "asc")
            {
                return await _dbContext.employees.OrderBy(m=>m.Age).ToListAsync();
            }
            else
            {
                return await _dbContext.employees.OrderByDescending(m => m.Age).ToListAsync();
            }
        }

        public override async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbContext.employees.Include(m=>m.Department).ToListAsync();
        }
    }
}
