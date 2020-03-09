using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;
using Swifty.Data.Context;

namespace Swifty.Data.Repositories
{
    public class SkillAreaRepository : SwiftyArchiveableRepository<SkillArea>
    {
        public SkillAreaRepository(SwiftyContext context) : base(context) { }
    }
}
