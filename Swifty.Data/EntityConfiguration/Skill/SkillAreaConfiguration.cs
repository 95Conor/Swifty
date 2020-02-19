using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Swifty.Data.EntityConfiguration
{
    public class SkillAreaConfiguration : IEntityTypeConfiguration<SkillArea>
    {
        public void Configure(EntityTypeBuilder<SkillArea> builder)
        {
            builder.HasKey(skillArea => skillArea.Id);

            builder.Property(skillArea => skillArea.Name)
                    .IsRequired();
        }
    }
}
