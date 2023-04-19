using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using ApiContext;
using Application;
using Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
         where TEntity : class
    {
        protected readonly DBContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DBContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsyc(TId id)
        {
            return await _dbSet.FindAsync(id);
        }

        

        public async Task<bool> DeleteAsync(TId id)
        {
            var item = await GetByIdAsyc(id);
            if (item != null)
            {
                _dbSet.Remove(item);
               await Save();
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public async Task<bool> UpdateAsync(TEntity item)
        {
            var entity = _dbSet.Update(item);
            if (entity != null)
            { await Save();
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
          
        }

        public async Task Save()
        {
             await _context.SaveChangesAsync();
        }

      public async Task<bool> CreateAsync(TEntity Entity)
        {
             await _dbSet.AddAsync(Entity);
           await Save();
            return true;
        }
    }
}
