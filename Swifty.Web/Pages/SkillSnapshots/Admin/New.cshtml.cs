using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Swifty.Core.Entities;
using Swifty.Core.Entities.ValueObjects.Skill;
using Swifty.Data.Contracts.Repositories;
using Swifty.Data.Contracts.Services;
using Swifty.Data.Extensions;
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
        private readonly IBaseRepository<User> _userRepository;
        private readonly ISkillSnapshotService<SkillSnapshot> _skillSnapshotService;

        public NewModel(IMapper mapper, 
            ISkillService<Skill> skillService, 
            IConfiguration configuration, 
            IBaseArchiveableRepository<Skill> skillRepository,
            IBaseRepository<User> userRepository,
            ISkillSnapshotService<SkillSnapshot> skillSnapshotService)
        {
            _mapper = mapper;
            _skillService = skillService;
            _configuration = configuration;
            _skillRepository = skillRepository;
            _userRepository = userRepository;
            _skillSnapshotService = skillSnapshotService;
        }

        [BindProperty]
        public NewViewModel NewViewModel { get; set; } = new NewViewModel();

        public SelectList Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return await ReturnPage();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var skillsAsSkillReferences = _mapper.Map<List<SkillReference>>(NewViewModel.UserReviewedSkills);
            string reviewerName = this.User.Claims.FirstOrDefault(x => x.Type.Equals(_configuration["Authorization:IdentityServer:ClaimsProperties:Email"]))?.Value;

            if (NewViewModel.SelectedUserId <= 0)
            {
                NewViewModel.ErrorMessages.Add("Please select a user");
                return await ReturnPage();
            }

            try
            {
                await _skillSnapshotService.CreateNew(skillsAsSkillReferences, reviewerName, NewViewModel.SelectedUserId, NewViewModel.ReviewerNotes);
                NewViewModel.SuccessMessages.Add($"Successfully created new Skill Snapshot at {DateTime.Now}.");
            }
            catch (Exception ex)
            {
                NewViewModel.ErrorMessages.Add($"Error creating new Skill Snapshot:{Environment.NewLine}{ex.Message}");
            }

            return await ReturnPage();
        }

        private async Task PopulateModels()
        {
            var allSkillsBySkillArea = await _skillService.ListAllNonArchivedSkillsByAreaAndLevel();

            NewViewModel.SkillsByArea = _mapper.Map<Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<ReviewedSkillViewModel>>>>(allSkillsBySkillArea);

            var allSkillEntities = await _skillRepository.ListAllNonArchivedAsync();

            NewViewModel.UserReviewedSkills = _mapper.Map<List<ReviewedSkillViewModel>>(allSkillEntities);

            Users = await _userRepository.BuildSelectListAsync(nameof(Swifty.Core.Entities.User.Email));
        }

        private async Task<IActionResult> ReturnPage()
        {
            await PopulateModels();
            return Page();
        }
    }
}