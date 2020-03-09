using Swifty.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swifty.Data.Contracts.Repositories
{
    public interface IBaseArchiveableRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IArchiveableEntity
    {
        public new Task DeleteAsync(TEntity entity);

        public Task ArchiveAsync(TEntity entity);
    }
}
