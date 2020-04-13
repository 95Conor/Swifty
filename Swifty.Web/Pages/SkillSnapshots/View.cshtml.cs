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

        public ViewModel(IMapper mapper,
            IConfiguration configuration,
            IAdminService<Admin> adminService,
            IUserService<User> userService,
            ISkillService<Skill> skillService,
            ISkillSnapshotService<SkillSnapshot> skillSnapshotService,
            IBaseArchiveableRepository<Skill> skillRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _adminService = adminService;
            _userService = userService;
            _skillService = skillService;
            _skillSnapshotService = skillSnapshotService;
            _skillRepository = skillRepository;
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

            //if (await _adminService.ValidateIsAdminByEmail(userEmail))
            //{
            //    return await OnGetAdminAsync();
            //}

            var userEntity = _userService.GetUserByEmail(userEmail);

            if (userEntity == null)
            {
                return NotFound();
            }

            var allSkillsBySkillArea = await _skillService.ListAllNonArchivedSkillsByAreaAndLevel();

            ViewViewModel.SkillsByArea = _mapper.Map<Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<ReviewedSkillViewModel>>>>(allSkillsBySkillArea);

            //var allSkillEntities = await _skillRepository.ListAllNonArchivedAsync();

            //IndexViewModel.UserReviewedSkills = _mapper.Map<List<ReviewedSkillViewModel>>(allSkillEntities);

            //var skillSnapshot = _skillSnapshotRepository.GetById(...)

            return Page();
        }

        //// To use when an admin browses to the page. Removed for now for testing 
        //private async Task<IActionResult> OnGetAdminAsync()
        //{
        //    return Page();
        //}
    }
}