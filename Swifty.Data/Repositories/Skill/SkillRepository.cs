using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Swifty.Core.Entities;
using Swifty.Data.Context;

namespace Swifty.Data.Repositories
{
    public class SkillRepository : SwiftyArchiveableRepository<Skill>
    {
        public SkillRepository(SwiftyContext context) : base(context) { }
    }
}
