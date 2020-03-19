using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Core.Entities
{
    public class SkillSetSkillLink : IEntityBase
    {
        public int Id { get; set; }

        [ForeignKey("LinkedSkill")]
        public int SkillId { get; set; }
        public Skill LinkedSkill { get; set; }

        [ForeignKey("LinkedSkillSet")]
        public int SkillSetId { get; set; }
        public SkillSet LinkedSkillSet { get; set; }
    }
}
