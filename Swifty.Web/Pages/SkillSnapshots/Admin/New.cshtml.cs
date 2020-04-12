using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Swifty.Core.Entities;
using Swifty.Data.Contracts.Repositories;
using Swifty.Data.Contracts.Services;
using Swifty.Web.ViewModels.Shared;
using Swifty.Web.ViewModels.SkillSnapshot;

namespace Swifty.Web.Pages.SkillSnaphsots.Admin
{
    [Authorize("IsAdmin")]
    public class NewModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ISkillService<Skill> _skillService;
        private readonly IConfiguration _configuration;
        private readonly IBaseArchiveableRepository<Skill> _skillRepository;

        public NewModel(IMapper mapper, ISkillService<Skill> skillService, IConfiguration configuration, IBaseArchiveableRepository<Skill> skillRepository)
        {
            _mapper = mapper;
            _skillService = skillService;
            _configuration = configuration;
            _skillRepository = skillRepository;
        }

        [BindProperty]
        public NewViewModel NewViewModel { get; set; } = new NewViewModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var allSkillsBySkillArea = await _skillService.ListAllNonArchivedSkillsByAreaAndLevel();

            NewViewModel.SkillsByArea = _mapper.Map<Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<ReviewedSkillViewModel>>>>(allSkillsBySkillArea);

            NewViewModel.AdminName = this.User.Claims.FirstOrDefault(x => x.Type.Equals(_configuration["Authorization:IdentityServer:ClaimsProperties:Email"]))?.Value;

            var allSkillEntities = await _skillRepository.ListAllNonArchivedAsync();

            NewViewModel.AllSkills = _mapper.Map<List<ReviewedSkillViewModel>>(allSkillEntities);

            return Page();
        }

        // On post - we should probably just map from the view models to get stuff we want to then pass to a SkillSnapshotService.CreateNewSkillSnapshot(user, admin name, green, red, yellow, datetime)
        public async Task<IActionResult> OnPostAsync()
        {
            var check = 0;

            return Page();
        }
    }
}