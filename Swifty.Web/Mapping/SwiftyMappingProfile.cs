using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Swifty.Core.Entities;
using Swifty.Web.ViewModels.Shared;
using Swifty.Web.ViewModels.SkillSnapshot;

namespace Swifty.Web.Mapping
{
    public class SwiftyMappingProfile : Profile
    {
        public SwiftyMappingProfile()
        {
            CreateMap<SkillArea, SkillAreaViewModel>().ReverseMap();

            CreateMap<SkillLevel, SkillLevelViewModel>().ReverseMap();

            CreateMap<Skill, SkillViewModel>().ReverseMap();

            CreateMap<Skill, ReviewedSkillViewModel>().ReverseMap();
        }
    }
}
