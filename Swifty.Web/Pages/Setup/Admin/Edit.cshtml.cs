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
    public class EditModel : PageModel
    {
        private readonly IBaseRepository<Entities.Admin> _adminRepository;

        public EditModel(IBaseRepository<Entities.Admin> adminRepository)
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

            if (Admin == null)
            {
                return NotFound();
            }

            Admin.Email = EncryptionHelper.Decrypt(Admin.Email);

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _adminRepository.UpdateAsync(Admin);

            return RedirectToPage("./Index");
        }
    }
}