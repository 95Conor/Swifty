using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Swifty.Data.EntityConfiguration
{
    public class SkillSetConfiguration : IEntityTypeConfiguration<SkillSet>
    {
        public void Configure(EntityTypeBuilder<SkillSet> builder)
        {
            builder.HasKey(skillSet => skillSet.Id);
        }
    }
}
