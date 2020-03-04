﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Swifty.Data.Context;
using Swifty.Data.Repositories;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.SkillLevel
{
    [Authorize(Policy = "IsAdmin")]
    public class CreateModel : PageModel
    {
        private readonly SwiftyRepository<Entities.SkillLevel> swiftyRepository;

        public CreateModel(SwiftyRepository<Entities.SkillLevel> swiftyRepository)
        {
            this.swiftyRepository = swiftyRepository;
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

            await swiftyRepository.AddAsync(SkillLevel);

            return RedirectToPage("./Index");
        }
    }
}
