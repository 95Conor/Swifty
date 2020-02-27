using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swifty.Data.Migrations
{
    public partial class Initialisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillSets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail = table.Column<string>(nullable: false),
                    LevelId = table.Column<int>(nullable: true),
                    AreaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_SkillAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "SkillAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_SkillLevels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "SkillLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillSnapshots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(nullable: false),
                    RedSkillsId = table.Column<int>(nullable: true),
                    AmberSkillsId = table.Column<int>(nullable: true),
                    GreenSkillsId = table.Column<int>(nullable: true),
                    SnapshotDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSnapshots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillSnapshots_SkillSets_AmberSkillsId",
                        column: x => x.AmberSkillsId,
                        principalTable: "SkillSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkillSnapshots_SkillSets_GreenSkillsId",
                        column: x => x.GreenSkillsId,
                        principalTable: "SkillSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkillSnapshots_SkillSets_RedSkillsId",
                        column: x => x.RedSkillsId,
                        principalTable: "SkillSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillSetSkillLink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkedSkillId = table.Column<int>(nullable: true),
                    LinkedSkillSetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSetSkillLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillSetSkillLink_Skills_LinkedSkillId",
                        column: x => x.LinkedSkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkillSetSkillLink_SkillSets_LinkedSkillSetId",
                        column: x => x.LinkedSkillSetId,
                        principalTable: "SkillSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AreaId",
                table: "Skills",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_LevelId",
                table: "Skills",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSetSkillLink_LinkedSkillId",
                table: "SkillSetSkillLink",
                column: "LinkedSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSetSkillLink_LinkedSkillSetId",
                table: "SkillSetSkillLink",
                column: "LinkedSkillSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSnapshots_AmberSkillsId",
                table: "SkillSnapshots",
                column: "AmberSkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSnapshots_GreenSkillsId",
                table: "SkillSnapshots",
                column: "GreenSkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSnapshots_RedSkillsId",
                table: "SkillSnapshots",
                column: "RedSkillsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillSetSkillLink");

            migrationBuilder.DropTable(
                name: "SkillSnapshots");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SkillSets");

            migrationBuilder.DropTable(
                name: "SkillAreas");

            migrationBuilder.DropTable(
                name: "SkillLevels");
        }
    }
}
