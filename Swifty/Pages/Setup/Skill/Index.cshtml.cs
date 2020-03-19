using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Swifty.Data.Contracts.Repositories;
using Swifty.Data.Extensions;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.Skill
{
    [Authorize(Policy = "IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.Skill> _skillRepository;
        private readonly IBaseArchiveableRepository<Entities.SkillArea> _skillAreaRepository;
        private readonly IBaseArchiveableRepository<Entities.SkillLevel> _skillLevelRepository;

        public IndexModel(IBaseArchiveableRepository<Entities.Skill> skillRepository, 
            IBaseArchiveableRepository<Entities.SkillArea> skillAreaRepository,
            IBaseArchiveableRepository<Entities.SkillLevel> skillLevelRepository)
        {
            _skillRepository = skillRepository;
            _skillAreaRepository = skillAreaRepository;
            _skillLevelRepository = skillLevelRepository;
        }

        public List<Entities.Skill> AllSkills { get; set; }

        public async Task OnGetAsync()
        {
            AllSkills = await _skillRepository.ListAllAsync();
        }
    }
}
