using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

namespace Swifty.Web.Pages.SkillSnapshots
{
    [Authorize("RequiresUserLogin")]
    public class IndexModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAdminService<Admin> _adminService;
        private readonly IUserService<User> _userService;
        private readonly ISkillSnapshotService<SkillSnapshot> _skillSnapshotService;
        private readonly IBaseRepository<SkillSnapshot> _skillSnapshotRepository;
        private readonly IBaseRepository<User> _userRepository;


        public IndexModel(IMapper mapper,
            IConfiguration configuration,
            IAdminService<Admin> adminService,
            IUserService<User> userService,
            ISkillSnapshotService<SkillSnapshot> skillSnapshotService,
            IBaseRepository<SkillSnapshot> skillSnapshotRepository,
            IBaseRepository<User> userRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            _adminService = adminService;
            _userService = userService;
            _skillSnapshotService = skillSnapshotService;
            _skillSnapshotRepository = skillSnapshotRepository;
            _userRepository = userRepository;
        }

        [BindProperty]
        public IndexViewModel IndexViewModel { get; set; } = new IndexViewModel();

        public async Task<IActionResult> OnGetAsync()
        {
            string userEmail = this.User.Claims.FirstOrDefault(x => x.Type.Equals(_configuration["Authorization:IdentityServer:ClaimsProperties:Email"]))?.Value;

            if (await _adminService.ValidateIsAdminByEmail(userEmail))
            {
                var allSkillSnapshots = await _skillSnapshotRepository.ListAllAsync();

                var allSkillSnapshotSummaries = _mapper.Map<List<SkillSnapshotSummaryViewModel>>(allSkillSnapshots);

                IndexViewModel.SkillSnapshotSummaries = await GroupSkillSnapshotSummariesByUser(allSkillSnapshotSummaries);
            }
            else
            {
                var userEntity = _userService.GetUserByEmail(userEmail);

                if (userEntity == null)
                {
                    return NotFound();
                }

                var userSkillSnapshots = await _skillSnapshotService.GetAllByUserEmail(userEmail);

                var userSkillSnapshotSummaries = _mapper.Map<List<SkillSnapshotSummaryViewModel>>(userSkillSnapshots);

                IndexViewModel.SkillSnapshotSummaries.Add(userEmail, userSkillSnapshotSummaries);
            }

            return Page();
        }

        private async Task<Dictionary<string, List<SkillSnapshotSummaryViewModel>>> GroupSkillSnapshotSummariesByUser(List<SkillSnapshotSummaryViewModel> skillSnapshotSummaries)
        {
            Dictionary<string, List<SkillSnapshotSummaryViewModel>> toReturn = new Dictionary<string, List<SkillSnapshotSummaryViewModel>>();

            foreach (SkillSnapshotSummaryViewModel skillSnapshotSummary in skillSnapshotSummaries)
            {
                var userEntity = await _userRepository.GetByIdAsync(skillSnapshotSummary.UserId);
                string userEmail = userEntity?.Email;

                if (toReturn.ContainsKey(userEmail))
                {
                    toReturn[userEmail].Add(skillSnapshotSummary);
                }
                else
                {
                    toReturn.Add(userEmail, new List<SkillSnapshotSummaryViewModel>() { skillSnapshotSummary });
                }
            }

            return toReturn;
        }
    }
}