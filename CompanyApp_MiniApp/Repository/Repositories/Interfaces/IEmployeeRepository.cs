using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesByAgeAsync(int age);
        Task<IEnumerable<Employee>> GetEmployeeByDepartmentIdAsync(int departmentId);
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentNameAsync(string departmentName);
        Task<IEnumerable<Employee>> SearchByNameOrSurnameAsync(string nameOrSurname);
        Task<int> GetCountAsync();
        Task<IEnumerable<Employee>> SortEmployeesByAgeAsync(string sort);
    }
}
