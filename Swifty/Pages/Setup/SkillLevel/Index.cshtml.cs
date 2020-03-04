using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Repositories;

namespace Swifty.Web
{
    [Authorize(Policy = "IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly SwiftyRepository<SkillLevel> swiftyRepository;

        public IndexModel(SwiftyRepository<SkillLevel> swiftyRepository)
        {
            this.swiftyRepository = swiftyRepository;
        }

        public List<SkillLevel> AllSkillLevels { get; set; }

        public async Task OnGetAsync()
        {
            AllSkillLevels = await swiftyRepository.ListAllAsync();
        }
    }
}
