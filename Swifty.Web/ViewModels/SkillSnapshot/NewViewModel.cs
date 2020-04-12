using Swifty.Web.ViewModels.Base;
using Swifty.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swifty.Web.ViewModels.SkillSnapshot
{
    public class NewViewModel : BaseViewModel
    {
        public Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<ReviewedSkillViewModel>>> SkillsByArea { get; set; } = new Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<ReviewedSkillViewModel>>>();

        public int SelectedUserId { get; set; }

        public string ReviewerNotes { get; set; }

        public string AdminName { get; set; }
    }
}
