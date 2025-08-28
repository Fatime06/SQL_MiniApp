using Domain.Entities;
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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }
        public async Task CreateAsync(Employee employee)
        {
           await _employeeRepository.CreateAsync(employee);
           await _employeeRepository.SaveChangeAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var delEmp =await _employeeRepository.GetByIdAsync(id);
            if (delEmp == null)
            {
                throw new NotFoundException(ExceptionMessage.NotFound);
            }
            await _employeeRepository.DeleteAsync(delEmp);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesByAgeAsync(int age)
        {
            var all = await _employeeRepository.GetAllEmployeesByAgeAsync(age);
            if (all == null)
            {
                throw new NotFoundException(ExceptionMessage.NotFound);
            }
            return all;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var allId= await _employeeRepository.GetByIdAsync(id);
            if(allId == null)
            {
                throw new NotFoundException(ExceptionMessage.NotFound);
            }
            return allId;
        }

        public async Task<int> GetCountAsync()
        {
            return await _employeeRepository.GetCountAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentIdAsync(int departmentId)
        {
            var empId = await _employeeRepository.GetEmployeeByDepartmentIdAsync(departmentId);
            if (empId == null)
            {
                throw new NotFoundException(ExceptionMessage.NotFound);
            }
            return empId;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentNameAsync(string departmentName)
        {
            var depN = await _employeeRepository.GetEmployeesByDepartmentNameAsync(departmentName);
            if (depN == null)
            {
                throw new NotFoundException(ExceptionMessage.NotFound);
            }
            return depN;
        }
        public async Task<IEnumerable<Employee>> SearchByNameOrSurnameAsync(string nameOrSurname)
        {
            var searchedN = await _employeeRepository.SearchByNameOrSurnameAsync(nameOrSurname);
            if (searchedN == null)
            {
                throw new NotFoundException(ExceptionMessage.NotFound);
            }
            return searchedN;
        }

        public async Task<IEnumerable<Employee>> SortEmployeesByAgeAsync(string sort)
        {
            return await _employeeRepository.SortEmployeesByAgeAsync(sort);
        }


    }
}
