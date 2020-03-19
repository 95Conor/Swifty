using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swifty.Data.Contracts.Repositories;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.SkillArea
{
    [Authorize(Policy = "IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.SkillArea> _skillAreaRepository;

        public IndexModel(IBaseArchiveableRepository<Entities.SkillArea> skillAreaRepository)
        {
            _skillAreaRepository = skillAreaRepository;
        }

        public List<Entities.SkillArea> AllSkillAreas { get; set; }

        public async Task OnGetAsync()
        {
            AllSkillAreas = await _skillAreaRepository.ListAllAsync();
        }
    }
}
