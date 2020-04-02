using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Entities = Swifty.Core.Entities;
using Swifty.Core.Helpers;
using Swifty.Data.Context;
using Swifty.Data.Contracts.Repositories;

namespace Swifty.Web.Pages.Setup.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IBaseRepository<Entities.Admin> _adminRepository;

        public IndexModel(IBaseRepository<Entities.Admin> adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IList<Entities.Admin> Admins { get;set; }

        public async Task OnGetAsync()
        {
            Admins = await _adminRepository.ListAllAsync();

            foreach (var admin in Admins)
            {
                admin.Email = EncryptionHelper.Decrypt(admin.Email);
            }
        }
    }
}
