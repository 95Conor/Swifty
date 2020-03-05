using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Core.Entities
{
    public class SkillSnapshot : EntityBase
    {
        public int Id { get; set; }

        public User User { get; set; }

        public SkillSet RedSkills { get; set; }

        public SkillSet AmberSkills { get; set; }

        public SkillSet GreenSkills { get; set; }

        public DateTime SnapshotDate { get; set; }
    }
}
