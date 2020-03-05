using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Core.Helpers;

namespace Swifty.Data.Repositories
{
    public class AdminRepository : SwiftyRepository<Admin>
    {
        public AdminRepository(SwiftyContext context) : base(context) { }

        public override async Task<Admin> AddAsync(Admin entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.Email))
            {
                entity.Email = EncryptionHelper.Encrypt(entity.Email);
            }

            await base.AddAsync(entity);

            return entity;
        }

        public override async Task UpdateAsync(Admin entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.Email))
            {
                entity.Email = EncryptionHelper.Encrypt(entity.Email);
            }

            await base.UpdateAsync(entity);
        }
    }
}
