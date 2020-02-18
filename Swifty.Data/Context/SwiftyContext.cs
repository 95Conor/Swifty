using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;

namespace Swifty.Data.Context
{
    public class SwiftyContext : DbContext
    {
        public SwiftyContext(DbContextOptions<SwiftyContext> options) : base(options)
        {

        }

        public DbSet<SkillLevel> SkillLevels { get; set; }

        public DbSet<SkillArea> SkillAreas { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<SkillSet> SkillSets { get; set; }

        public DbSet<SkillSnapshot> SkillSnapshots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Might need some stuff in here, or it might just work
        }
    }
}

