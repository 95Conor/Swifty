using Microsoft.EntityFrameworkCore.Migrations;

namespace Swifty.Data.Migrations
{
    public partial class Skill_ForeignKeyImplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillAreas_AreaId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillLevels_LevelId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_AreaId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_LevelId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "SkillAreaId",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillLevelId",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillAreaId",
                table: "Skills",
                column: "SkillAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillLevelId",
                table: "Skills",
                column: "SkillLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillAreas_SkillAreaId",
                table: "Skills",
                column: "SkillAreaId",
                principalTable: "SkillAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillLevels_SkillLevelId",
                table: "Skills",
                column: "SkillLevelId",
                principalTable: "SkillLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillAreas_SkillAreaId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillLevels_SkillLevelId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SkillAreaId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SkillLevelId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillAreaId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillLevelId",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AreaId",
                table: "Skills",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_LevelId",
                table: "Skills",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillAreas_AreaId",
                table: "Skills",
                column: "AreaId",
                principalTable: "SkillAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillLevels_LevelId",
                table: "Skills",
                column: "LevelId",
                principalTable: "SkillLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
