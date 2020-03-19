using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swifty.Data.Contracts.Repositories;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.SkillLevel
{
    [Authorize(Policy = "IsAdmin")]
    public class CreateModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.SkillLevel> _skillLevelRepository;

        public CreateModel(IBaseArchiveableRepository<Entities.SkillLevel> skillLevelRepository)
        {
            _skillLevelRepository = skillLevelRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entities.SkillLevel SkillLevel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _skillLevelRepository.AddAsync(SkillLevel);

            return RedirectToPage("./Index");
        }
    }
}
