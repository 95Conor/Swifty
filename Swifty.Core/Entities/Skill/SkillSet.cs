using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Core.Entities
{
    public class SkillSet
    {
        public int Id { get; set; }

        public List<Skill> Set { get; set; }
    }
}
