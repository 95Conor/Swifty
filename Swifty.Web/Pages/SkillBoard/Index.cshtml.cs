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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace Swifty.Web.Pages.SkillBoard
{
    [Authorize("RequiresUserLogin")]
    public class IndexModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ISkillService<Skill> _skillService;
        private readonly IAdminService<Admin> _adminService;
        private readonly IConfiguration _configuration;

        public IndexModel(IMapper mapper, ISkillService<Skill> skillService, IAdminService<Admin> adminService, IConfiguration configuration)
        {
            _mapper = mapper;
            _skillService = skillService;
            _adminService = adminService;
            _configuration = configuration;
        }

        [BindProperty]
        public IndexViewModel IndexViewModel { get; set; } = new IndexViewModel();

        public async Task<IActionResult> OnGetAsync()
        {
            var allSkillsBySkillArea = await _skillService.ListAllNonArchivedSkillsByAreaAndLevel();

            IndexViewModel.SkillsByArea = _mapper.Map<Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<SkillViewModel>>>>(allSkillsBySkillArea);

            string emailClaim = this.User.Claims.FirstOrDefault(x => x.Type.Equals(_configuration["Authorization:IdentityServer:ClaimsProperties:Email"]))?.Value;

            IndexViewModel.DisplayAdminOptions = await _adminService.ValidateIsAdminByEmail(emailClaim);

            return Page();
        }
    }
}