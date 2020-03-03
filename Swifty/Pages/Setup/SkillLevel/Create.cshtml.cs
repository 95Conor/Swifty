using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Repositories;

namespace Swifty.Web
{
    public class CreateModel : PageModel
    {
        private readonly SwiftyRepository<SkillLevel> swiftyRepository;

        public CreateModel(SwiftyRepository<SkillLevel> swiftyRepository)
        {
            this.swiftyRepository = swiftyRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SkillLevel SkillLevel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await swiftyRepository.AddAsync(SkillLevel);

            return RedirectToPage("./Index");
        }
    }
}
