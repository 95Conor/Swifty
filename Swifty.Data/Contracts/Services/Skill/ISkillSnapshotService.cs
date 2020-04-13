using Swifty.Core.Contracts.Entities;
using Swifty.Core.Entities.ValueObjects.Skill;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Swifty.Data.Contracts.Services
{
    public interface ISkillSnapshotService<TEntity> : IEntityService<TEntity> where TEntity : class, IEntityBase
    {
        public Task CreateNew(List<SkillReference> skillReferences, string reviewerName, int userId, string reviewerNotes);
    }
}
