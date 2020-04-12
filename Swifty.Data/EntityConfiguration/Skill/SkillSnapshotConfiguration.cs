using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Swifty.Data.EntityConfiguration
{
    public class SkillSnapshotConfiguration : IEntityTypeConfiguration<SkillSnapshot>
    {
        public void Configure(EntityTypeBuilder<SkillSnapshot> builder)
        {
            builder.HasKey(skillSnapshot => skillSnapshot.Id);

            builder.Property(skillSnapshot => skillSnapshot.SnapshotDate)
                    .HasColumnType("Date")
                    .HasDefaultValueSql("GetDate()");

            builder.OwnsOne(ss => ss.UserId, x => x.Property(user => user.Id).HasColumnName("UserId"));

            builder.OwnsMany(ss => ss.SkillReferences, SkillReferenceConfiguration.Configure);
        }
    }
}
