using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Data.Contracts.Services;
using Swifty.Core.Entities;
using Swifty.Data.Contracts.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace Swifty.Data.Services
{
    public class SkillService : ISkillService<Skill>
    {
        private readonly IBaseArchiveableRepository<Skill> _skillRepository;

        public SkillService(IBaseArchiveableRepository<Skill> skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<Dictionary<SkillArea, List<Skill>>> ListAllSkillsBySkillArea()
        {
            List<Skill> allSkills = await _skillRepository.ListAllAsync();

            Dictionary<SkillArea, List<Skill>> toReturn = new Dictionary<SkillArea, List<Skill>>();

            foreach (Skill skill in allSkills)
            {
                if (toReturn.ContainsKey(skill.Area))
                {
                    toReturn[skill.Area].Add(skill);
                }
                else
                {
                    toReturn.Add(skill.Area, new List<Skill>() { skill });
                }
            }

            return toReturn;
        }

        public async Task<Dictionary<SkillArea, List<Skill>>> ListAllNonArchivedSkillsBySkillArea()
        {
            List<Skill> allSkills = await _skillRepository.ListAllNonArchivedAsync();

            Dictionary<SkillArea, List<Skill>> toReturn = new Dictionary<SkillArea, List<Skill>>();

            foreach (Skill skill in allSkills)
            {
                if (toReturn.ContainsKey(skill.Area))
                {
                    toReturn[skill.Area].Add(skill);
                }
                else
                {
                    if (!skill.Area.IsArchived)
                    {
                        toReturn.Add(skill.Area, new List<Skill>());
                    }
                }
            }

            return toReturn;
        }
    }
}
