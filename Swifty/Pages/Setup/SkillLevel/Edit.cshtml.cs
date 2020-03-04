using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Repositories;

namespace Swifty.Web
{
    [Authorize(Policy = "IsAdmin")]
    public class EditModel : PageModel
    {
        private readonly SwiftyRepository<SkillLevel> swiftyRepository;

        public EditModel(SwiftyRepository<SkillLevel> swiftyRepository)
        {
            this.swiftyRepository = swiftyRepository;
        }

        [BindProperty]
        public SkillLevel SkillLevel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SkillLevel = await swiftyRepository.GetByIdAsync(id.Value);

            if (SkillLevel == null)
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

            await swiftyRepository.UpdateAsync(SkillLevel);

            return RedirectToPage("./Index");
        }
    }
}
