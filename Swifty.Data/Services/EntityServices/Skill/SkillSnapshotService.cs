using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Data.Contracts.Services;
using Swifty.Core.Entities;
using System.Threading.Tasks;
using Swifty.Core.Entities.ValueObjects.Skill;
using Swifty.Core.Entities.ValueObjects.Auth;
using Swifty.Data.Contracts.Repositories;
using System.Linq;

namespace Swifty.Data.Services
{
    public class SkillSnapshotService : ISkillSnapshotService<SkillSnapshot>
    {
        private readonly IBaseRepository<SkillSnapshot> _skillSnapshotRepository;
        private readonly IUserService<User> _userService;

        public SkillSnapshotService(IBaseRepository<SkillSnapshot> skillSnapshotRepository, IUserService<User> userService)
        {
            _skillSnapshotRepository = skillSnapshotRepository;
            _userService = userService;
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

        public async Task<List<SkillSnapshot>> GetAllByUserEmail(string userEmail)
        {
            var skillSnapshots = await _skillSnapshotRepository.ListAllAsync();

            List<SkillSnapshot> toReturn = new List<SkillSnapshot>();

            if (skillSnapshots != null && skillSnapshots.Any())
            {
                var user = await _userService.GetUserByEmail(userEmail);

                if (user != null)
                {
                    toReturn = skillSnapshots.Where(x => x.UserId.Id == user.Id).ToList();
                }
            }

            return toReturn;
        }
    }
}
