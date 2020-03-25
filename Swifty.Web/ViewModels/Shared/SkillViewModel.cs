using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swifty.Web.ViewModels.Shared
{
    public class SkillViewModel
    {
        public int Id { get; set; }

        public SkillAreaViewModel SkillArea { get; set; }

        public SkillLevelViewModel SkillLevel { get; set; }

        public bool IsArchived { get; set; }

        public string Detail { get; set; }
    }
}
