﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.SkillLevel> _skillLevelRepository;

        public DetailsModel(IBaseArchiveableRepository<Entities.SkillLevel> skillLevelRepository)
        {
            _skillLevelRepository = skillLevelRepository;
        }

        public Entities.SkillLevel SkillLevel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SkillLevel = await _skillLevelRepository.GetByIdAsync(id.Value);

            if (SkillLevel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
