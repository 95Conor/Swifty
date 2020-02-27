using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Core.Entities
{
    public class SkillSet : IEntityBase
    {
        public int Id { get; set; }

        public ICollection<SkillSetSkillLink> Set { get; set; }
    }
}
