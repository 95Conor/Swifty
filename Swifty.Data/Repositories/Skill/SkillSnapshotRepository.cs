using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swifty.Core.Entities;
using Swifty.Data.Context;

namespace Swifty.Data.Repositories
{
    public class SkillSnapshotRepository : SwiftyRepository<SkillSnapshot>
    {
        public SkillSnapshotRepository(SwiftyContext context) : base(context) { }

        public override async Task<List<SkillSnapshot>> ListAllAsync()
        {
            var all = await base.ListAllAsync();

            all.OrderBy(x => x.SnapshotDate);

            return all;
        }
    }
}
