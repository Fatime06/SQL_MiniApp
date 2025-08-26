using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(int id);
    }
}
