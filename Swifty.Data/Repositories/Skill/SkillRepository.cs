using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Swifty.Core.Entities;
using Swifty.Data.Context;

namespace Swifty.Data.Repositories
{
    public class SkillRepository : SwiftyRepository<Skill>
    {
        public SkillRepository(SwiftyContext context) : base(context) { }

        public override Task DeleteAsync(Skill entity)
        {
            entity.IsArchived = true;
            return base.UpdateAsync(entity);
        }
    }
}
