using Microsoft.EntityFrameworkCore.Migrations;

namespace Swifty.Data.Migrations
{
    public partial class Auth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "SkillSnapshots");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SkillSnapshots",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillSnapshots_UserId",
                table: "SkillSnapshots",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_User_UserId",
                table: "SkillSnapshots",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillSnapshots_User_UserId",
                table: "SkillSnapshots");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_SkillSnapshots_UserId",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SkillSnapshots");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "SkillSnapshots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
