using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Swifty.Core.Entities;
using Swifty.Data.Contracts.Repositories;
using Swifty.Data.Contracts.Services;
using Swifty.Web.ViewModels.Shared;
using Swifty.Web.ViewModels.SkillSnapshot;

namespace Swifty.Web.Pages.SkillSnapshots
{
    public class ViewModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAdminService<Admin> _adminService;
        private readonly IUserService<User> _userService;
        private readonly ISkillService<Skill> _skillService;
        private readonly ISkillSnapshotService<SkillSnapshot> _skillSnapshotService;
        private readonly IBaseArchiveableRepository<Skill> _skillRepository;
        private readonly IBaseRepository<SkillSnapshot> _skillSnapshotRepository;

        public ViewModel(IMapper mapper,
            IConfiguration configuration,
            IAdminService<Admin> adminService,
            IUserService<User> userService,
            ISkillService<Skill> skillService,
            ISkillSnapshotService<SkillSnapshot> skillSnapshotService,
            IBaseArchiveableRepository<Skill> skillRepository,
            IBaseRepository<SkillSnapshot> skillSnapshotRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _adminService = adminService;
            _userService = userService;
            _skillService = skillService;
            _skillSnapshotService = skillSnapshotService;
            _skillRepository = skillRepository;
            _skillSnapshotRepository = skillSnapshotRepository;
        }

        [BindProperty]
        public ViewViewModel ViewViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            string userEmail = this.User.Claims.FirstOrDefault(x => x.Type.Equals(_configuration["Authorization:IdentityServer:ClaimsProperties:Email"]))?.Value;

            var skillSnapshot = await _skillSnapshotRepository.GetByIdAsync(id.Value);
            var user = await _userService.GetUserByEmail(userEmail);

            if (skillSnapshot == null)
            {
                return NotFound();
            }

            if (!await _adminService.ValidateIsAdminByEmail(userEmail) && user?.Id != skillSnapshot.UserId.Id)
            {
                return RedirectToPagePermanent("/Account/AccessDenied");
            }

            var allSkillsBySkillArea = await _skillService.ListAllNonArchivedSkillsByAreaAndLevel();

            ViewViewModel.SkillsByArea = _mapper.Map<Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<ReviewedSkillViewModel>>>>(allSkillsBySkillArea);

            ViewViewModel.SkillSnapshotSummary = _mapper.Map<SkillSnapshotSummaryViewModel>(skillSnapshot);

            ViewViewModel.UserReviewedSkills = _mapper.Map<List<ReviewedSkillViewModel>>(skillSnapshot.SkillReferences);

            return Page();
        }
    }
}