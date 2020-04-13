using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Swifty.Core.Entities;
using Swifty.Core.Entities.ValueObjects.Skill;
using Swifty.Core.Enums;
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

            CreateMap<ReviewedSkillViewModel, SkillReference>()
                .ForMember(dest => dest.Colour, opts => opts.MapFrom(src => 
                    src.ReviewedRed ? SkillColour.Red :
                    src.ReviewedAmber ? SkillColour.Amber :
                    src.ReviewedGreen ? SkillColour.Green :
                    SkillColour.NotSet
                ));
        }
    }
}
