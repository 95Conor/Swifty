using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swifty.Data.Contracts
{
    public interface IBaseRepository<TEntity> : IBaseReadRepository<TEntity>
    {
        public Task<TEntity> AddAsync(TEntity entity);

        public Task UpdateAsync(TEntity entity);

        public Task DeleteAsync(TEntity entity);
    }
}
