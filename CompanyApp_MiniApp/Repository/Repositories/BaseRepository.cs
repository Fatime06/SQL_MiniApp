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
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDBContext _dbContext;
        private DbSet<T> _table;
        public BaseRepository()
        {
            _dbContext = new AppDBContext();
            _table = _dbContext.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _table.AddAsync(entity);

        }

        public async Task DeleteAsync(T entity)
        {
            _table.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
