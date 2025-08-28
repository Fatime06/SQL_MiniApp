using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {


        public async Task<IEnumerable<Department>> SearchAsync(string name)
        {
            return await _dbContext.departments.Where(m => m.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            _dbContext.departments.Update(department);
            await _dbContext.SaveChangesAsync();
        }
    }
}
