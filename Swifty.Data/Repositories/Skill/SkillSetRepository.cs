using System;
using System.Collections.Generic;
using System.Linq;
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
        private IBaseRepository<SkillSetSkillLink> _skillSetSkillLinkRepository;

        public SkillSetRepository(SwiftyContext context, IBaseArchiveableRepository<Skill> skillRepository, IBaseRepository<SkillSetSkillLink> skillSetSkillLinkRepository) : base(context) 
        {
            _skillRepository = skillRepository;
            _skillSetSkillLinkRepository = skillSetSkillLinkRepository;
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

        public override async Task<SkillSet> AddAsync(SkillSet entity)
        {
            await PersistSkillLinkCollection(entity);
            return await base.AddAsync(entity);
        }

        public override Task UpdateAsync(SkillSet entity)
        {
            PersistSkillLinkCollection(entity).Wait();
            return base.UpdateAsync(entity);
        }

        // Hacky fix - map from SkillLinkCollection to Set (Skill List) when loading a SkillSet entity
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

        // Hacky fix - map from Set (Skill List) to SkillLinkCollection when saving a SkillSet entity
        private async Task PersistSkillLinkCollection(SkillSet entity)
        {
            var allSkillSetSkillLinks = await _skillSetSkillLinkRepository.ListAllAsync();

            foreach (var skill in entity.Set)
            {
                if (!allSkillSetSkillLinks.Any(x => x.SkillId == skill.Id && x.SkillSetId == entity.Id))
                {
                    entity.SkillLinkCollection.Add(new SkillSetSkillLink() { SkillId = skill.Id, SkillSetId = entity.Id });
                }
                else
                {
                    var skillSetSkillLinkEntity = allSkillSetSkillLinks.Where(x => x.SkillId == skill.Id && x.SkillSetId == entity.Id).FirstOrDefault();
                    entity.SkillLinkCollection.Add(skillSetSkillLinkEntity);
                }
            }
        }
    }
}
