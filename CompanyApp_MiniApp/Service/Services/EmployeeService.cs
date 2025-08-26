using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public async Task CreateAsync(Employee employee)
        {
           await _employeeRepository.CreateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesByAgeAsync(int age)
        {
            return await _employeeRepository.GetAllEmployeesByAgeAsync(age);
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _employeeRepository.GetCountAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentIdAsync(int departmentId)
        {
            return await _employeeRepository.GetEmployeeByDepartmentIdAsync(departmentId);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentNameAsync(string departmentName)
        {
            return await _employeeRepository.GetEmployeesByDepartmentNameAsync(departmentName);
        }
        public async Task<IEnumerable<Employee>> SearchByNameOrSurnameAsync(string nameOrSurname)
        {
            return await _employeeRepository.SearchByNameOrSurnameAsync(nameOrSurname);
        }

        public async Task<IEnumerable<Employee>> SortEmployeesByAgeAsync(string sort)
        {
            return await _employeeRepository.SortEmployeesByAgeAsync(sort);
        }
    }
}
