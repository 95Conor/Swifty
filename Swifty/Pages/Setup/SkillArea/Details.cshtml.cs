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
    public class DetailsModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.SkillArea> swiftyRepository;

        public DetailsModel(IBaseArchiveableRepository<Entities.SkillArea> swiftyRepository)
        {
            this.swiftyRepository = swiftyRepository;
        }

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
    }
}
