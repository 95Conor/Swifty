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
    public class EditModel : PageModel
    {
        private readonly IBaseArchiveableRepository<Entities.Skill> _skillRepository;
        private readonly IBaseArchiveableRepository<Entities.SkillArea> _skillAreaRepository;
        private readonly IBaseArchiveableRepository<Entities.SkillLevel> _skillLevelRepository;

        public EditModel(IBaseArchiveableRepository<Entities.Skill> skillRepository,
            IBaseArchiveableRepository<Entities.SkillArea> skillAreaRepository,
            IBaseArchiveableRepository<Entities.SkillLevel> skillLevelRepository)
        {
            _skillRepository = skillRepository;
            _skillAreaRepository = skillAreaRepository;
            _skillLevelRepository = skillLevelRepository;
        }

        [BindProperty]
        public Entities.Skill Skill { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            PopulateSelectListsAsync();

            if (id == null)
            {
                return NotFound();
            }

            Skill = await _skillRepository.GetByIdAsync(id.Value);

            if (Skill == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateSelectListsAsync();
                return Page();
            }

            await _skillRepository.UpdateAsync(Skill);

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
