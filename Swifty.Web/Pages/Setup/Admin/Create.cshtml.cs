using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities = Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Contracts.Repositories;

namespace Swifty.Web.Pages.Setup.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IBaseRepository<Entities.Admin> _adminRepository;

        public CreateModel(IBaseRepository<Entities.Admin> adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entities.Admin Admin { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _adminRepository.AddAsync(Admin);

            return RedirectToPage("./Index");
        }
    }
}
