using Microsoft.EntityFrameworkCore.Migrations;

namespace Swifty.Data.Migrations
{
    public partial class SkillSnapshot_AdminReviewer_AdminNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminNotes",
                table: "SkillSnapshots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminReveiwer",
                table: "SkillSnapshots",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminNotes",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "AdminReveiwer",
                table: "SkillSnapshots");
        }
    }
}
