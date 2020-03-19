using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Core.Entities
{
    public class SkillSnapshot : IEntityBase
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("RedSkills")]
        public int RedSkillSetId { get; set; }
        public SkillSet RedSkills { get; set; }

        [ForeignKey("AmberSkills")]
        public int AmberSkillSetId { get; set; }
        public SkillSet AmberSkills { get; set; }

        [ForeignKey("GreenSkills")]
        public int GreenSkillSetId { get; set; }
        public SkillSet GreenSkills { get; set; }

        public DateTime SnapshotDate { get; set; }
    }
}
