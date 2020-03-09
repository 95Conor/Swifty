﻿using Swifty.Core.Contracts.Entities;
using Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
    }
}