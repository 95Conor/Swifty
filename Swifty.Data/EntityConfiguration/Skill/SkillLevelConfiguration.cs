using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Swifty.Data.EntityConfiguration
{
    public class SkillLevelConfiguration : IEntityTypeConfiguration<SkillLevel>
    {
        public void Configure(EntityTypeBuilder<SkillLevel> builder)
        {
            builder.HasKey(skillLevel => skillLevel.Id);

            builder.Property(skillLevel => skillLevel.Value)
                    .IsRequired();

            builder.Property(skillLevel => skillLevel.IsArchived).HasDefaultValue(false);
        }
    }
}
