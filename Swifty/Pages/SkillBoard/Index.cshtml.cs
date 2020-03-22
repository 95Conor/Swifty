using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swifty.Core.Entities;
using Swifty.Data.Contracts.Services;

namespace Swifty.Web.Pages.SkillBoard
{
    public class IndexModel : PageModel
    {
        private readonly ISkillService<Skill> _skillService;

        public IndexModel(ISkillService<Skill> skillService)
        {
            _skillService = skillService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var allSkillBySkillArea = await _skillService.ListAllNonArchivedSkillsBySkillArea();

            return Page();
        }
    }
}