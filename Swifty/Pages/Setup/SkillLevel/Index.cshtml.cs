using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Swifty.Data.Context;
using Swifty.Data.Repositories;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.SkillLevel
{
    [Authorize(Policy = "IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly SwiftyRepository<Entities.SkillLevel> swiftyRepository;

        public IndexModel(SwiftyRepository<Entities.SkillLevel> swiftyRepository)
        {
            this.swiftyRepository = swiftyRepository;
        }

        public List<Entities.SkillLevel> AllSkillLevels { get; set; }

        public async Task OnGetAsync()
        {
            AllSkillLevels = await swiftyRepository.ListAllAsync();
        }
    }
}
