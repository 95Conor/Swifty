﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swifty.Web.ViewModels.Base;
using Swifty.Web.ViewModels.Shared;

namespace Swifty.Web.ViewModels.SkillBoard
{
    public class IndexViewModel : BaseViewModel
    {
        public Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<SkillViewModel>>> SkillsByArea { get; set; } = new Dictionary<SkillAreaViewModel, Dictionary<SkillLevelViewModel, List<SkillViewModel>>>();

        public bool DisplayAdminOptions { get; set; } = false;
    }
}
