using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Swifty.Core.Entities;
using System.Reflection;

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

        public DbSet<SkillSnapshot> SkillSnapshots { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // All configuration done in separate configuration classes - See EntityConfiguration folder
            // These can all be registered with the below extenion method
            // https://www.learnentityframeworkcore.com/configuration/fluent-api

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

