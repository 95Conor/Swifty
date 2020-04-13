using Swifty.Web.ViewModels.Base;
using Swifty.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swifty.Web.ViewModels.SkillSnapshot
{
    public class IndexViewModel : BaseViewModel
    {
        // Lists all skillsnapshots they can see by user (so if you're not admin, it will just be one key for their own user)
        public Dictionary<string, List<SkillSnapshotSummaryViewModel>> SkillSnapshotSummaries { get; set; } = new Dictionary<string, List<SkillSnapshotSummaryViewModel>>();
    }
}
