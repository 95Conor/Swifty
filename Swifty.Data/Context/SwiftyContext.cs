using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Data.Context
{
    public class SwiftyContext : DbContext
    {
        public SwiftyContext(DbContextOptions<SwiftyContext> options) : base(options)
        {
        }

        // The below will hold all the relevant skill entities within DbSets

        //public DbSet<Skill> Students { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
        //public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>().ToTable("Course");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}

