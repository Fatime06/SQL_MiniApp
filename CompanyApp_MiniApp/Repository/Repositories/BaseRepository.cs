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
        private DbSet<T> _dbSet;
        public BaseRepository()
        {
            _dbContext = new AppDBContext();
            _dbSet = _dbContext.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public async Task DeleteAsync(int id)
        {
            var res =await _dbSet.FindAsync(id);
            _dbSet.Remove(res);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
