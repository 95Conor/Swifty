using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Swifty.Data.Contracts;
using Swifty.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Swifty.Data.Repositories
{
    public class SwiftyRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SwiftyContext dbContext;

        public SwiftyRepository(SwiftyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<List<TEntity>> ListAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            dbContext.Update(entity);
            return dbContext.SaveChangesAsync();
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            return dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> ListWhereAsync(Func<TEntity, bool> criteria)
        {
            var resultSet = dbContext.Set<TEntity>().Where(criteria).AsQueryable();

            if (!(resultSet is IAsyncEnumerable<TEntity>))
            {
                return await Task.FromResult(resultSet.ToList());
            }

            return await resultSet.ToListAsync();
        }
    }
}
