using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swifty.Data.Contracts.Repositories;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.Skill
{
    [Authorize(Policy = "IsAdmin")]
    public class EditModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.Skill> swiftyRepository;

        public EditModel(IBaseArchiveableRepository<Entities.Skill> swiftyRepository)
        {
            this.swiftyRepository = swiftyRepository;
        }

        [BindProperty]
        public Entities.Skill Skill { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Skill = await swiftyRepository.GetByIdAsync(id.Value);

            if (Skill == null)
            {
                return NotFound();
            }
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

            await swiftyRepository.UpdateAsync(Skill);

            return RedirectToPage("./Index");
        }
    }
}
