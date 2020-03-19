using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Core.Entities
{
    public class Skill : IArchiveableEntity
    {
        public int Id { get; set; }

        public string Detail { get; set; }

        public bool IsArchived { get; set; }

        [ForeignKey("Level")]
        public int SkillLevelId { get; set; }
        public SkillLevel Level { get; set; }

        [ForeignKey("Area")]
        public int SkillAreaId { get; set; }
        public SkillArea Area { get; set; }
    }
}
