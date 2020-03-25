using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swifty.Data.Contracts.Repositories;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.SkillArea
{
    [Authorize(Policy = "IsAdmin")]
    public class DeleteModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.SkillArea> _skillAreaRepository;

        public DeleteModel(IBaseArchiveableRepository<Entities.SkillArea> skillAreaRepository)
        {
            _skillAreaRepository = skillAreaRepository;
        }

        [BindProperty]
        public Entities.SkillArea SkillArea { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SkillArea = await _skillAreaRepository.GetByIdAsync(id.Value);

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

            SkillArea = await _skillAreaRepository.GetByIdAsync(id.Value);

            if (SkillArea != null)
            {
                await _skillAreaRepository.DeleteAsync(SkillArea);
            }

            return RedirectToPage("./Index");
        }
    }
}
