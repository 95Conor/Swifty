using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Entities = Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Contracts.Repositories;
using Swifty.Core.Helpers;

namespace Swifty.Web.Pages.Setup.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly IBaseRepository<Entities.Admin> _adminRepository;

        public DetailsModel(IBaseRepository<Entities.Admin> adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Entities.Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Admin = await _adminRepository.GetByIdAsync(id.Value);

            if (Admin == null)
            {
                return NotFound();
            }

            Admin.Email = EncryptionHelper.Decrypt(Admin.Email);

            return Page();
        }
    }
}
