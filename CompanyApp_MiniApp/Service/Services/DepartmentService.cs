using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Helpers.Constants;
using Service.Helpers.Exceptions;
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
                throw new NotFoundException(ExceptionMessage.NotFound);
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
                throw new NotFoundException(ExceptionMessage.NotFound);
            }
            return result;
        }

        public async Task<IEnumerable<Department>> SearchAsync(string name)
        {
            var searched =  await _departmentRepo.SearchAsync(name);
            if (searched == null)
            {
                throw new NotFoundException(ExceptionMessage.NotFound);
            }
            return searched;
        }

        public async Task UpdateDepartmentAsync(int id, Department department)
        {
            var existDepartment = await _departmentRepo.GetByIdAsync(id);
            if (existDepartment == null) return;

            if (!string.IsNullOrWhiteSpace(department.Name))
            {
                existDepartment.Name = department.Name;
            }

            if (department.Capacity > 0)
            {
                existDepartment.Capacity = department.Capacity;
            }


            await _departmentRepo.UpdateDepartmentAsync(existDepartment);
        }



    }
}
