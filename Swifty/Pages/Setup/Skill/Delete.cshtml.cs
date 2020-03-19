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
    public class DeleteModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.Skill> _skillRepository;

        public DeleteModel(IBaseArchiveableRepository<Entities.Skill> skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [BindProperty]
        public Entities.Skill Skill { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Skill = await _skillRepository.GetByIdAsync(id.Value);

            if (Skill == null)
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

            Skill = await _skillRepository.GetByIdAsync(id.Value);

            if (Skill != null)
            {
                await _skillRepository.DeleteAsync(Skill);
            }

            return RedirectToPage("./Index");
        }
    }
}
