using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Swifty.Core.Contracts.Entities;
using Swifty.Core.Entities.ValueObjects.Auth;
using Swifty.Core.Entities.ValueObjects.Skill;
using Swifty.Core.Enums;

namespace Swifty.Core.Entities
{
    public partial class SkillSnapshot : IEntityBase
    {
        public int Id { get; set; }

        public UserId UserId { get; set; }

        private readonly List<SkillReference> _skillReferences = new List<SkillReference>();
        public IReadOnlyCollection<SkillReference> SkillReferences => _skillReferences.AsReadOnly();

        public DateTime SnapshotDate { get; set; }

        public string AdminReviewer { get; set; }

        public string AdminNotes { get; set; }
    }
}
