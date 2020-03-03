using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Repositories;

namespace Swifty.Web
{
    public class DeleteModel : PageModel
    {
        private readonly SwiftyRepository<SkillLevel> swiftyRepository;

        public DeleteModel(SwiftyRepository<SkillLevel> swiftyRepository)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SkillLevel = await swiftyRepository.GetByIdAsync(id.Value);

            if (SkillLevel != null)
            {
                await swiftyRepository.DeleteAsync(SkillLevel);
            }

            return RedirectToPage("./Index");
        }
    }
}
