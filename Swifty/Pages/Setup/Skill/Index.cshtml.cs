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

        public IndexModel(IBaseArchiveableRepository<Entities.Skill> skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public List<Entities.Skill> AllSkills { get; set; }

        public async Task OnGetAsync()
        {
            AllSkills = await _skillRepository.ListAllAsync();
            await PopulateSelectListsAsync();
        }

        public SelectList SkillLevelSelectList { get; set; }

        public SelectList SkillAreaSelectList { get; set; }

        private async Task PopulateSelectListsAsync()
        {
            var skillLevelTask = swiftyRepository.BuildSelectListExcludeArchivedAsync(nameof(Entities.SkillLevel.Value));
            var skillAreaTask = swiftyRepository.BuildSelectListExcludeArchivedAsync(nameof(Entities.SkillArea.Name));

            await Task.WhenAll(skillLevelTask, skillAreaTask);

            SkillLevelSelectList = skillLevelTask.Result;
            SkillAreaSelectList = skillAreaTask.Result;
        }
    }
}
