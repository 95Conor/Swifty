using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swifty.Data.Contracts.Repositories;
using System.Threading.Tasks;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.Admin
{
    [Authorize("IsAdmin")]
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