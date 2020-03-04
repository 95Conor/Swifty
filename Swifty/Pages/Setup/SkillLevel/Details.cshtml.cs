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

namespace Swifty.Web.Pages.Setup.SkillLevel
{
    [Authorize(Policy = "IsAdmin")]
    public class DetailsModel : PageModel
    {
        private readonly SwiftyRepository<Entities.SkillLevel> swiftyRepository;

        public DetailsModel(SwiftyRepository<Entities.SkillLevel> swiftyRepository)
        {
            this.swiftyRepository = swiftyRepository;
        }

        public Entities.SkillLevel SkillLevel { get; set; }

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
    }
}
