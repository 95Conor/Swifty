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
    public class CreateModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.SkillArea> _skillAreaRepository;

        public CreateModel(IBaseArchiveableRepository<Entities.SkillArea> skillAreaRepository)
        {
            _skillAreaRepository = skillAreaRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entities.SkillArea SkillArea { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _skillAreaRepository.AddAsync(SkillArea);

            return RedirectToPage("./Index");
        }
    }
}
