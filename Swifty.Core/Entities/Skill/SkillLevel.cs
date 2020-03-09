using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Core.Entities
{
    public class SkillLevel : IArchiveableEntity
    {
        public int Id { get; set; }

        public bool IsArchived { get; set; }

        public int Value { get; set; }
    }
}
