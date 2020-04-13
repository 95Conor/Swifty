using Swifty.Web.ViewModels.Base;
using Swifty.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swifty.Web.ViewModels.SkillSnapshot
{
    public class ViewViewModel : BaseViewModel
    {
        public Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<ReviewedSkillViewModel>>> SkillsByArea { get; set; } = new Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<ReviewedSkillViewModel>>>();

        public List<ReviewedSkillViewModel> UserReviewedSkills { get; set; }

        public SkillSnapshotSummaryViewModel SkillSnapshotSummary { get; set; }
    }
}
