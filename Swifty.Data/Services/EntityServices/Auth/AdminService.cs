using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Data.Contracts.Services;
using Swifty.Core.Entities;
using Swifty.Data.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Swifty.Core.Helpers;
using Swifty.Data.Contracts.Repositories;

namespace Swifty.Data.Services
{
    public class AdminService : IAdminService<Admin>
    {
        private readonly IBaseRepository<Admin> adminRepository;

        public AdminService(IBaseRepository<Admin> adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public async Task<bool> ValidateIsAdminByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            var adminEntities = await adminRepository.ListAllAsync();

            if (adminEntities != null && adminEntities.FirstOrDefault(x => EncryptionHelper.Decrypt(x.Email).ToLower() == email.ToLower()) != null)
            {
                return true;
            }

            return false;
        }
    }
}
