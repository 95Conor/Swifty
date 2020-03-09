using Swifty.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Data.Contracts
{
    public interface IBaseReadRepository<TEntity> where TEntity : class, IEntityBase
    {
        public Task<TEntity> GetByIdAsync(int id);

        public Task<List<TEntity>> ListAllAsync();

        public Task<List<TEntity>> ListWhereAsync(Func<TEntity, bool> criteria);
    }
}
