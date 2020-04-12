using Microsoft.EntityFrameworkCore.Migrations;

namespace Swifty.Data.Migrations
{
    public partial class SkillSnapshot_ValueObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillSnapshots_SkillSets_AmberSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSnapshots_SkillSets_GreenSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSnapshots_SkillSets_RedSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSnapshots_Users_UserId",
                table: "SkillSnapshots");

            migrationBuilder.DropTable(
                name: "SkillSetSkillLink");

            migrationBuilder.DropTable(
                name: "SkillSets");

            migrationBuilder.DropIndex(
                name: "IX_SkillSnapshots_AmberSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.DropIndex(
                name: "IX_SkillSnapshots_GreenSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.DropIndex(
                name: "IX_SkillSnapshots_RedSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.DropIndex(
                name: "IX_SkillSnapshots_UserId",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "AdminReveiwer",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "AmberSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "GreenSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "RedSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SkillSnapshots",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AdminReviewer",
                table: "SkillSnapshots",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SkillSnapshotSkillReferences",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false),
                    SkillSnapshotId = table.Column<int>(nullable: false),
                    SkillColour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSnapshotSkillReferences", x => new { x.SkillSnapshotId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_SkillSnapshotSkillReferences_SkillSnapshots_SkillSnapshotId",
                        column: x => x.SkillSnapshotId,
                        principalTable: "SkillSnapshots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillSnapshotSkillReferences");

            migrationBuilder.DropColumn(
                name: "AdminReviewer",
                table: "SkillSnapshots");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SkillSnapshots",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdminReveiwer",
                table: "SkillSnapshots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmberSkillSetId",
                table: "SkillSnapshots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GreenSkillSetId",
                table: "SkillSnapshots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedSkillSetId",
                table: "SkillSnapshots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SkillSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillSetSkillLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    SkillSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSetSkillLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillSetSkillLink_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillSetSkillLink_SkillSets_SkillSetId",
                        column: x => x.SkillSetId,
                        principalTable: "SkillSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillSnapshots_AmberSkillSetId",
                table: "SkillSnapshots",
                column: "AmberSkillSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSnapshots_GreenSkillSetId",
                table: "SkillSnapshots",
                column: "GreenSkillSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSnapshots_RedSkillSetId",
                table: "SkillSnapshots",
                column: "RedSkillSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSnapshots_UserId",
                table: "SkillSnapshots",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSetSkillLink_SkillId",
                table: "SkillSetSkillLink",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSetSkillLink_SkillSetId",
                table: "SkillSetSkillLink",
                column: "SkillSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_SkillSets_AmberSkillSetId",
                table: "SkillSnapshots",
                column: "AmberSkillSetId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_SkillSets_GreenSkillSetId",
                table: "SkillSnapshots",
                column: "GreenSkillSetId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_SkillSets_RedSkillSetId",
                table: "SkillSnapshots",
                column: "RedSkillSetId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_Users_UserId",
                table: "SkillSnapshots",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
