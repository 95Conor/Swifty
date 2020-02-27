using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;
using Swifty.Data.Context;

namespace Swifty.Data.Repositories
{
    public class SkillLevelRepository : SwiftyRepository<SkillLevel>
    {
        public SkillLevelRepository(SwiftyContext context) : base(context) { }
    }
}
