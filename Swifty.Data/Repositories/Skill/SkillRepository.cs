using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Contracts.Repositories;

namespace Swifty.Data.Repositories
{
    public class SkillRepository : SwiftyArchiveableRepository<Skill>
    {
        private readonly IBaseArchiveableRepository<SkillArea> _skillAreaRepository;
        private readonly IBaseArchiveableRepository<SkillLevel> _skillLevelRepository;

        public SkillRepository(SwiftyContext context, 
            IBaseArchiveableRepository<SkillArea> skillAreaRepository,
            IBaseArchiveableRepository<SkillLevel> skillLevelRepository) : base(context) 
        {
            _skillAreaRepository = skillAreaRepository;
            _skillLevelRepository = skillLevelRepository;
        }

        public override async Task<List<Skill>> ListAllAsync()
        {
            var allEntities = await base.ListAllAsync();

            await PersistAreaAndLevels(allEntities);

            return allEntities;
        }

        public override async Task<List<Skill>> ListAllNonArchivedAsync()
        {
            var allEntities = await base.ListAllNonArchivedAsync();

            await PersistAreaAndLevels(allEntities);

            return allEntities;
        }

        private async Task PersistAreaAndLevels(List<Skill> skills)
        {
            foreach (var entity in skills)
            {
                try
                {
                    entity.Area = await _skillAreaRepository.GetByIdAsync(entity.SkillAreaId);
                    entity.Level = await _skillLevelRepository.GetByIdAsync(entity.SkillLevelId);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }

        public override async Task<Skill> GetByIdAsync(int id)
        {
            var entity = await base.GetByIdAsync(id);

            try
            {
                entity.Area = await _skillAreaRepository.GetByIdAsync(entity.SkillAreaId);
                entity.Level = await _skillLevelRepository.GetByIdAsync(entity.SkillLevelId);
            }
            catch (Exception ex) 
            {
                throw (ex);
            }

            return entity;
        }
    }
}
