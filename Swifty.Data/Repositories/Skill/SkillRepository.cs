using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;
using Swifty.Data.Context;

namespace Swifty.Data.Repositories
{
    public class SkillRepository : SwiftyRepository<Skill>
    {
        public SkillRepository(SwiftyContext context) : base(context) { }
    }
}
