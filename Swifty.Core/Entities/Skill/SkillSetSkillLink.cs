using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Core.Entities
{
    public class SkillSetSkillLink
    {
        public int Id { get; set; }

        public Skill LinkedSkill { get; set; }

        public SkillSet LinkedSkillSet { get; set; }
    }
}
