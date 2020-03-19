using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swifty.Data.Contracts.Repositories;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.Skill
{
    [Authorize(Policy = "IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.Skill> _skillRepository;

        public IndexModel(IBaseArchiveableRepository<Entities.Skill> skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public List<Entities.Skill> AllSkills { get; set; }

        public async Task OnGetAsync()
        {
            AllSkills = await _skillRepository.ListAllAsync();
        }
    }
}
