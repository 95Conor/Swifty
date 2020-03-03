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

        public override async Task<List<Admin>> ListAllAsync()
        {
            var entities = await base.ListAllAsync();

            foreach (var entity in entities)
            {
                if (!string.IsNullOrWhiteSpace(entity.Email))
                {
                    entity.Email = EncryptionHelper.Decrypt(entity.Email);
                }
            }

            return entities;
        }

        public override async Task<Admin> GetByIdAsync(int id)
        {
            var entity = await base.GetByIdAsync(id);

            if (!string.IsNullOrWhiteSpace(entity.Email))
            {
                entity.Email = EncryptionHelper.Decrypt(entity.Email);
            }

            return entity;
        }
    }
}
