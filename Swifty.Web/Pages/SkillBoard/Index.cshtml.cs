using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swifty.Core.Entities;
using Swifty.Data.Contracts.Services;
using Swifty.Web.ViewModels.SkillBoard;
using AutoMapper;
using Swifty.Web.ViewModels.Shared;

namespace Swifty.Web.Pages.SkillBoard
{
    public class IndexModel : PageModel
    {
        private readonly ISkillService<Skill> _skillService;
        private readonly IMapper _mapper;

        public IndexModel(ISkillService<Skill> skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [BindProperty]
        public IndexViewModel IndexViewModel { get; set; } = new IndexViewModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var allSkillsBySkillArea = await _skillService.ListAllNonArchivedSkillsByAreaAndLevel();

            var allSkillsBySkillAreaViewModels = _mapper.Map<Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<SkillViewModel>>>>(allSkillsBySkillArea);

            IndexViewModel.SkillsByArea = allSkillsBySkillAreaViewModels;

            return Page();
        }
    }
}