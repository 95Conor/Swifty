using Swifty.Core.Contracts.Entities;
using Swifty.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swifty.Data.Contracts.Services
{
    public interface ISkillService<TEntity> : IEntityService<TEntity> where TEntity : class, IEntityBase
    {
        public Task<Dictionary<SkillArea, List<Skill>>> ListAllSkillsBySkillArea();

        public Task<Dictionary<SkillArea, List<Skill>>> ListAllNonArchivedSkillsBySkillArea();
    }
}
