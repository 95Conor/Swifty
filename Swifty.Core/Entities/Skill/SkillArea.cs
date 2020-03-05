using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Contracts.Entities;

namespace Swifty.Core.Entities
{
    public class SkillArea : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
