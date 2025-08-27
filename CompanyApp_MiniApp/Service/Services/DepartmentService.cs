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

           var delDepart = await _departmentRepo.GetByIdAsync(id);
            if (delDepart == null)
            {

            }
          await _departmentRepo.DeleteAsync(delDepart);
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _departmentRepo.GetAllAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
          var result= await _departmentRepo.GetByIdAsync(id);
            if (result == null)
            {

            }
            return result;
        }

        public async Task<IEnumerable<Department>> SearchAsync(string name)
        {
            var searched =  await _departmentRepo.SearchAsync(name);
            if (searched == null)
            {

            }
            return searched;
        }

        public Task UpdateDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
