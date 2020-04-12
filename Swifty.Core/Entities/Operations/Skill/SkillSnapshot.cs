using Swifty.Core.Entities.ValueObjects.Skill;
using Swifty.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swifty.Core.Entities
{
    public partial class SkillSnapshot
    {
        public void AddSkillReference(SkillReference skill)
        {
            if (!_skillReferences.Contains(skill))
            {
                _skillReferences.Add(skill);
            }
        }

        public void UpdateSkillReferences(IEnumerable<SkillReference> skills)
        {
            foreach (var nonMatchingSkillReference in _skillReferences.Except(skills).ToList())
            {
                _skillReferences.Remove(nonMatchingSkillReference);
            }

            foreach (var addedSkillReference in skills.Except(_skillReferences).ToList())
            {
                AddSkillReference(addedSkillReference);
            }
        }
    }
}
