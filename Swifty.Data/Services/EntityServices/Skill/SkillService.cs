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

        public async Task<Dictionary<SkillArea, Dictionary<SkillLevel, List<Skill>>>> ListAllSkillsByAreaAndLevel()
        {
            return await GetAllSkillsByAreaAndLevel(excludeArchived: false);
        }


        public async Task<Dictionary<SkillArea, Dictionary<SkillLevel, List<Skill>>>> ListAllNonArchivedSkillsByAreaAndLevel()
        {
            return await GetAllSkillsByAreaAndLevel(excludeArchived: true);
        }


        // Ideally I should use classes for this much nesting and separate the logic into separate functions in future, this is too messy
        private async Task<Dictionary<SkillArea, Dictionary<SkillLevel, List<Skill>>>> GetAllSkillsByAreaAndLevel(bool excludeArchived)
        {
            List<Skill> allSkills = excludeArchived ? await _skillRepository.ListAllNonArchivedAsync() : await _skillRepository.ListAllAsync();

            Dictionary<SkillArea, Dictionary<SkillLevel, List<Skill>>> toReturn = new Dictionary<SkillArea, Dictionary<SkillLevel, List<Skill>>>();

            // Loop through all skills
            foreach (Skill skill in allSkills)
            {
                // If we've already grouped by this area, add to the dictionary using skill area as key
                if (toReturn.ContainsKey(skill.Area))
                {
                    if (!excludeArchived || (!skill.Area.IsArchived && !skill.Level.IsArchived))
                    {
                        // Add to collection based on level key if we have found this level before
                        if (toReturn[skill.Area].ContainsKey(skill.Level))
                        {
                            toReturn[skill.Area][skill.Level].Add(skill);
                        }
                        else
                        {
                            // Instantiate new dictionary if we haven't found this level before
                            toReturn[skill.Area].Add(skill.Level, new List<Skill>() { skill });
                            
                        }
                    }
                }
                else
                {
                    // If we haven't grouped by this area yet, add to the dictionary as a new key
                    if (!excludeArchived || (!skill.Area.IsArchived && !skill.Level.IsArchived))
                    {
                        toReturn.Add(skill.Area,
                            new Dictionary<SkillLevel, List<Skill>>()
                        {
                                { skill.Level , new List<Skill>() { skill } }
                        });
                    }
                }
            }

            return toReturn;
        }
    }
}
