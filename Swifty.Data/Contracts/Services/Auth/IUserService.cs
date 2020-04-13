using Swifty.Core.Contracts.Entities;
using Swifty.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swifty.Data.Contracts.Services
{
    public interface IUserService<TEntity> : IEntityService<TEntity> where TEntity : class, IEntityBase
    {
        public Task InitialiseLogin(string userEmail);

        public Task<User> GetUserByEmail(string userEmail);
    }
}
