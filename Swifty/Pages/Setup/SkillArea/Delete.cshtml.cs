using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Swifty.Data.Context;
using Swifty.Data.Repositories;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.SkillArea
{
    [Authorize(Policy = "IsAdmin")]
    public class DeleteModel : PageModel
    {
        private readonly SwiftyRepository<Entities.SkillArea> swiftyRepository;

        public DeleteModel(SwiftyRepository<Entities.SkillArea> swiftyRepository)
        {
            this.swiftyRepository = swiftyRepository;
        }

        [BindProperty]
        public Entities.SkillArea SkillArea { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SkillArea = await swiftyRepository.GetByIdAsync(id.Value);

            if (SkillArea == null)
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

            SkillArea = await swiftyRepository.GetByIdAsync(id.Value);

            if (SkillArea != null)
            {
                await swiftyRepository.DeleteAsync(SkillArea);
            }

            return RedirectToPage("./Index");
        }
    }
}
