using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Swifty.Data.Contracts.Repositories;
using Swifty.Data.Extensions;
using Entities = Swifty.Core.Entities;

namespace Swifty.Web.Pages.Setup.Skill
{
    [Authorize(Policy = "IsAdmin")]
    public class CreateModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.Skill> _skillRepository;
        private readonly IBaseArchiveableRepository<Entities.SkillArea> _skillAreaRepository;
        private readonly IBaseArchiveableRepository<Entities.SkillLevel> _skillLevelRepository;

        public CreateModel(IBaseArchiveableRepository<Entities.Skill> skillRepository,
            IBaseArchiveableRepository<Entities.SkillArea> skillAreaRepository,
            IBaseArchiveableRepository<Entities.SkillLevel> skillLevelRepository)
        {
            _skillRepository = skillRepository;
            _skillAreaRepository = skillAreaRepository;
            _skillLevelRepository = skillLevelRepository;
        }

        public async Task OnGetAsync()
        {
            await PopulateSelectListsAsync();
        }

        [BindProperty]
        public Entities.Skill Skill { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync();
                return Page();
            }

            await _skillRepository.AddAsync(Skill);

            return RedirectToPage("./Index");
        }

        public SelectList SkillLevelSelectList { get; set; }

        public SelectList SkillAreaSelectList { get; set; }

        private async Task PopulateSelectListsAsync()
        {
            var skillLevelTask = _skillLevelRepository.BuildSelectListExcludeArchivedAsync(nameof(Entities.SkillLevel.Value));
            var skillAreaTask = _skillAreaRepository.BuildSelectListExcludeArchivedAsync(nameof(Entities.SkillArea.Name));

            await Task.WhenAll(skillLevelTask, skillAreaTask);

            SkillLevelSelectList = skillLevelTask.Result;
            SkillAreaSelectList = skillAreaTask.Result;
        }
    }
}
