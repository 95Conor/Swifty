using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Core.Entities
{
    public class SkillSetSkillLink : EntityBase
    {
        public int Id { get; set; }

        public Skill LinkedSkill { get; set; }

        public SkillSet LinkedSkillSet { get; set; }
    }
}
