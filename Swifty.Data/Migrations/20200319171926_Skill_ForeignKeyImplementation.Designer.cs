﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Swifty.Data.Context;

namespace Swifty.Data.Migrations
{
    [DbContext(typeof(SwiftyContext))]
    [Migration("20200319171926_Skill_ForeignKeyImplementation")]
    partial class Skill_ForeignKeyImplementation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Swifty.Core.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Swifty.Core.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("SkillAreaId")
                        .HasColumnType("int");

                    b.Property<int>("SkillLevelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkillAreaId");

                    b.HasIndex("SkillLevelId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Swifty.Core.Entities.SkillArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsArchived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SkillAreas");
                });

            modelBuilder.Entity("Swifty.Core.Entities.SkillLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsArchived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SkillLevels");
                });

            modelBuilder.Entity("Swifty.Core.Entities.SkillSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("SkillSets");
                });

            modelBuilder.Entity("Swifty.Core.Entities.SkillSetSkillLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LinkedSkillId")
                        .HasColumnType("int");

                    b.Property<int?>("LinkedSkillSetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LinkedSkillId");

                    b.HasIndex("LinkedSkillSetId");

                    b.ToTable("SkillSetSkillLink");
                });

            modelBuilder.Entity("Swifty.Core.Entities.SkillSnapshot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AmberSkillsId")
                        .HasColumnType("int");

                    b.Property<int?>("GreenSkillsId")
                        .HasColumnType("int");

                    b.Property<int?>("RedSkillsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SnapshotDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AmberSkillsId");

                    b.HasIndex("GreenSkillsId");

                    b.HasIndex("RedSkillsId");

                    b.HasIndex("UserId");

                    b.ToTable("SkillSnapshots");
                });

            modelBuilder.Entity("Swifty.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Swifty.Core.Entities.Skill", b =>
                {
                    b.HasOne("Swifty.Core.Entities.SkillArea", "Area")
                        .WithMany()
                        .HasForeignKey("SkillAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Swifty.Core.Entities.SkillLevel", "Level")
                        .WithMany()
                        .HasForeignKey("SkillLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Swifty.Core.Entities.SkillSetSkillLink", b =>
                {
                    b.HasOne("Swifty.Core.Entities.Skill", "LinkedSkill")
                        .WithMany()
                        .HasForeignKey("LinkedSkillId");

                    b.HasOne("Swifty.Core.Entities.SkillSet", "LinkedSkillSet")
                        .WithMany("Set")
                        .HasForeignKey("LinkedSkillSetId");
                });

            modelBuilder.Entity("Swifty.Core.Entities.SkillSnapshot", b =>
                {
                    b.HasOne("Swifty.Core.Entities.SkillSet", "AmberSkills")
                        .WithMany()
                        .HasForeignKey("AmberSkillsId");

                    b.HasOne("Swifty.Core.Entities.SkillSet", "GreenSkills")
                        .WithMany()
                        .HasForeignKey("GreenSkillsId");

                    b.HasOne("Swifty.Core.Entities.SkillSet", "RedSkills")
                        .WithMany()
                        .HasForeignKey("RedSkillsId");

                    b.HasOne("Swifty.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
