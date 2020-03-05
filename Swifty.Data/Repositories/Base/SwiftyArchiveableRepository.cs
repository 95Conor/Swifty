using Swifty.Core.Contracts.Entities;
using Swifty.Core.Entities;
using Swifty.Core.Entities.Base;
using Swifty.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swifty.Data.Repositories
{
    public class SwiftyArchiveableRepository<TEntity> : SwiftyRepository<TEntity> where TEntity : ArchiveableEntityBase
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
    }
}
