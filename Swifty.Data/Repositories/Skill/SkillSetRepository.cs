using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Swifty.Core.Entities;
using Swifty.Data.Context;
using Swifty.Data.Contracts.Repositories;

namespace Swifty.Data.Repositories
{
    public class SkillSetRepository : SwiftyRepository<SkillSet>
    {
        private IBaseArchiveableRepository<Skill> _skillRepository;

        public SkillSetRepository(SwiftyContext context, IBaseArchiveableRepository<Skill> skillRepository) : base(context) 
        {
            _skillRepository = skillRepository;
        }

        public override async Task<List<SkillSet>> ListAllAsync()
        {
            var entities = await base.ListAllAsync();

            foreach (var entity in entities)
            {
                await PersistSkillCollection(entity);
            }

            return entities;
        }

        public override async Task<SkillSet> GetByIdAsync(int id)
        {
            var entity = await base.GetByIdAsync(id);
            await PersistSkillCollection(entity);
            return entity;
        }

        // Hacky fix - ensure the collections are mapped and peristed when save/loading
        private async Task PersistSkillCollection(SkillSet entity)
        {
            if (entity.SkillLinkCollection != null && entity.SkillLinkCollection.Count > 0)
            {
                List<Skill> skillEntitiesMapped = new List<Skill>();

                foreach (var skillLink in entity.SkillLinkCollection)
                {
                    var skillEntity = await _skillRepository.GetByIdAsync(skillLink.SkillId);
                    
                    if (skillEntity != null)
                    {
                        skillEntitiesMapped.Add(skillEntity);
                    }
                }

                entity.Set = skillEntitiesMapped;
            }
        }
    }
}
