using Swifty.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swifty.Data.Contracts.Services
{
    public interface IAdminService<TEntity> : IEntityService<TEntity> where TEntity : class, IEntityBase
    {
        public Task<bool> ValidateIsAdminByEmail(string email);
    }
}
