using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swifty.Core.Helpers;
using Swifty.Data.Contracts.Repositories;
using System.Threading.Tasks;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.Admin
{
    [Authorize("IsAdmin")]
    public class DeleteModel : PageModel
    {
        private readonly IBaseRepository<Entities.Admin> _adminRepository;

        public DeleteModel(IBaseRepository<Entities.Admin> adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [BindProperty]
        public Entities.Admin Admin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Admin = await _adminRepository.GetByIdAsync(id.Value);

            Admin.Email = EncryptionHelper.Decrypt(Admin.Email);

            if (Admin == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Admin = await _adminRepository.GetByIdAsync(id.Value);

            if (Admin != null)
            {
                await _adminRepository.DeleteAsync(Admin);
            }

            return RedirectToPage("./Index");
        }
    }
}