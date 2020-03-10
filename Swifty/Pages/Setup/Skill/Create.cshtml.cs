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
    public class CreateModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.Skill> swiftyRepository;

        public CreateModel(IBaseArchiveableRepository<Entities.Skill> swiftyRepository)
        {
            this.swiftyRepository = swiftyRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entities.Skill Skill { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await swiftyRepository.AddAsync(Skill);

            return RedirectToPage("./Index");
        }
    }
}
