using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Data.Contracts.Services;
using Swifty.Core.Entities;
using System.Threading.Tasks;
using Swifty.Core.Entities.ValueObjects.Skill;
using Swifty.Core.Entities.ValueObjects.Auth;
using Swifty.Data.Contracts.Repositories;

namespace Swifty.Data.Services
{
    public class SkillSnapshotService : ISkillSnapshotService<SkillSnapshot>
    {
        private readonly IBaseRepository<SkillSnapshot> _skillSnapshotRepository;

        public SkillSnapshotService(IBaseRepository<SkillSnapshot> skillSnapshotRepository)
        {
            _skillSnapshotRepository = skillSnapshotRepository;
        }

        public async Task CreateNew(List<SkillReference> skillReferences, string adminReviewer, int userId, string adminNotes)
        {
            var skillSnapshot = new SkillSnapshot();

            skillSnapshot.UserId = new UserId() { Id = userId };
            skillSnapshot.AdminReviewer = adminReviewer;
            skillSnapshot.AdminNotes = adminNotes;
            skillSnapshot.UpdateSkillReferences(skillReferences);
            skillSnapshot.SnapshotDate = DateTime.Now;

            await _skillSnapshotRepository.AddAsync(skillSnapshot);
        }
    }
}
