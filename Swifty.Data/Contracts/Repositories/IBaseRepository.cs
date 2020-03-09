using Swifty.Core.Contracts.Entities;
using Swifty.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swifty.Data.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> : IBaseReadRepository<TEntity> where TEntity : class, IEntityBase
    {
        public Task<TEntity> AddAsync(TEntity entity);

        public Task UpdateAsync(TEntity entity);

        public Task DeleteAsync(TEntity entity);
    }
}
