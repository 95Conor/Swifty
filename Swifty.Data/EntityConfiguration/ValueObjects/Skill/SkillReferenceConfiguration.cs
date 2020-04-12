using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Swifty.Core.Entities;
using Swifty.Core.Entities.ValueObjects.Skill;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Data.EntityConfiguration
{
    internal static class SkillReferenceConfiguration
    {
        internal static void Configure(OwnedNavigationBuilder<SkillSnapshot, SkillReference> builder)
        {
            builder.ToTable(name: "SkillSnapshotSkillReferences");

            builder.WithOwner()
                .HasForeignKey("SkillSnapshotId");

            builder.Property(id => id.Id)
                .HasColumnName("SkillId")
                .ValueGeneratedNever();

            builder.Property(colour => colour.Colour)
                .HasColumnName("SkillColour");

            builder.HasKey("SkillSnapshotId", "Id");
        }
    }
}
