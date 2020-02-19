using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Swifty.Data.EntityConfiguration
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(skill => skill.Id);

            builder.Property(skill => skill.Detail)
                    .IsRequired();
        }
    }
}
