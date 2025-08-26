using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        Task UpdateDepartmentAsync(Department department);
        Task<IEnumerable<Department>> SearchAsync(string name);
    }
}
