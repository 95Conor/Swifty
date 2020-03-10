using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swifty.Data.Contracts.Repositories;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.Skill
{
    [Authorize(Policy = "IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.Skill> swiftyRepository;

        public IndexModel(IBaseArchiveableRepository<Entities.Skill> swiftyRepository)
        {
            this.swiftyRepository = swiftyRepository;
        }

        public List<Entities.Skill> AllSkills { get; set; }

        public async Task OnGetAsync()
        {
            AllSkills = await swiftyRepository.ListAllAsync();
        }
    }
}
