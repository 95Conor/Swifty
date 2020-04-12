using Swifty.Core.Entities.ValueObjects.Base;
using Swifty.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Core.Entities.ValueObjects.Skill
{
    public class SkillReference : ValueObject
    {
        public int? Id { get; set; }

        public SkillColour Colour { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Colour;
        }
    }
}
