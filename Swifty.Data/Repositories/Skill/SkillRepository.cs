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

            foreach (var entity in allEntities)
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

            return allEntities;
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
