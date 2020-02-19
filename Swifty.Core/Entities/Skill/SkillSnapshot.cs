using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Core.Entities
{
    public class SkillSnapshot
    {
        public int Id { get; set; }

        // This will probably change to use user entity or something? Maybe we will just save the name/email - need to cross this bridge.
        public string User { get; set; }

        public SkillSet RedSkills { get; set; }

        public SkillSet AmberSkills { get; set; }

        public SkillSet GreenSkills { get; set; }

        public DateTime SnapshotDate { get; set; }
    }
}
