using Swifty.Core.Contracts.Entities;
using Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swifty.Core.Attributes;

namespace Swifty.Data.Repositories
{
    public class SwiftyArchiveableRepository<TEntity> : SwiftyRepository<TEntity>, IBaseArchiveableRepository<TEntity> where TEntity : class, IArchiveableEntity
    {
        public SwiftyArchiveableRepository(SwiftyContext dbContext) : base(dbContext)
        {
        }

        public override Task DeleteAsync(TEntity entity)
        {
            return ArchiveAsync(entity);
        }

        public Task ArchiveAsync(TEntity entity)
        {
            entity.IsArchived = true;
            return base.UpdateAsync(entity);
        }

        public virtual async Task<List<TEntity>> ListAllNonArchivedAsync()
        {
            var entities = await base.ListAllAsync();

            if (entities.Any())
            {
                entities = entities.Where(x => !x.IsArchived).ToList();
            }

            return entities;
        }

        [ListAllArchivedWarning]
        public override async Task<List<TEntity>> ListAllAsync()
        {
            return await base.ListAllAsync();
        }
    }
}
