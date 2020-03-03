﻿using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Data.Contracts.Services;
using Swifty.Core.Entities;
using Swifty.Data.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace Swifty.Data.Services
{
    public class AdminService : IEntityService<Admin>
    {
        private readonly SwiftyRepository<Admin> adminRepository;

        public AdminService(SwiftyRepository<Admin> adminRepository)
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

            if (adminEntities != null && adminEntities.FirstOrDefault(x => x.Email.ToLower() == email.ToLower()) != null)
            {
                return true;
            }

            return false;
        }
    }
}
