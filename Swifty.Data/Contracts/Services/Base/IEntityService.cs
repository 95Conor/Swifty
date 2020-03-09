using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Data.Contracts.Services
{
    public interface IEntityService<TEntity> where TEntity : class, IEntityBase
    {
    }
}
