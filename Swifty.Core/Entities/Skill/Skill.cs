using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Core.Entities
{
    public class Skill
    {
        public int Id { get; set; }

        public string Detail { get; set; }

        public SkillLevel Level { get; set; }

        public SkillArea Area { get; set; }
    }
}
