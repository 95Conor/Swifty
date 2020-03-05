using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Contracts.Entities;
using Swifty.Core.Entities.Base;

namespace Swifty.Core.Entities
{
    public class Skill : ArchiveableEntityBase
    {
        public int Id { get; set; }

        public string Detail { get; set; }

        public override bool IsArchived { get; set; }

        public SkillLevel Level { get; set; }

        public SkillArea Area { get; set; }
    }
}
