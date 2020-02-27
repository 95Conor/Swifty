using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swifty.Data.Contracts
{
    public interface IBaseReadRepository<TEntity>
    {
        public Task<TEntity> GetByIdAsync(int id);

        public Task<IReadOnlyList<TEntity>> ListAllAsync();

        public Task<IReadOnlyList<TEntity>> ListWhereAsync(Func<TEntity, bool> criteria);
    }
}
