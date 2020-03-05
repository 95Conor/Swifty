using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Core.Entities
{
    public class Skill : IEntityBase
    {
        public int Id { get; set; }

        public string Detail { get; set; }

        public bool IsArchived { get; set; }

        public SkillLevel Level { get; set; }

        public SkillArea Area { get; set; }
    }
}
