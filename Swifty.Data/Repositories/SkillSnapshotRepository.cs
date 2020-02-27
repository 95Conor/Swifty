using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;
using Swifty.Data.Context;

namespace Swifty.Data.Repositories
{
    public class SkillSnapshotRepository : SwiftyRepository<SkillSnapshot>
    {
        public SkillSnapshotRepository(SwiftyContext context) : base(context) { }
    }
}
