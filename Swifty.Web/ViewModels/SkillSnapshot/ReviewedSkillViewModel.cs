using Swifty.Web.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swifty.Web.ViewModels.SkillSnapshot
{
    public class ReviewedSkillViewModel
    {
        public int Id { get; set; }

        public SkillAreaViewModel SkillArea { get; set; }

        public SkillLevelViewModel SkillLevel { get; set; }

        public bool IsArchived { get; set; }

        public string Detail { get; set; }

        public bool ReviewedGreen { get; set; }

        public bool ReviewedAmber { get; set; }

        public bool ReviewedRed { get; set; }
    }
}
