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

        public int SkillAreaId { get; set; }

        public int SkillLevelId { get; set; }

        public bool IsArchived { get; set; }

        public string Detail { get; set; }

        public bool ReviewedGreen { get; set; }

        public bool ReviewedAmber { get; set; }

        public bool ReviewedRed { get; set; }
    }
}
