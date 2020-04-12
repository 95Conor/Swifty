using Microsoft.EntityFrameworkCore.Migrations;

namespace Swifty.Data.Migrations
{
    public partial class Global_ForeignKeyImplementation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillSetSkillLink_Skills_LinkedSkillId",
                table: "SkillSetSkillLink");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSetSkillLink_SkillSets_LinkedSkillSetId",
                table: "SkillSetSkillLink");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSnapshots_SkillSets_AmberSkillsId",
                table: "SkillSnapshots");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSnapshots_SkillSets_GreenSkillsId",
                table: "SkillSnapshots");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSnapshots_SkillSets_RedSkillsId",
                table: "SkillSnapshots");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSnapshots_Users_UserId",
                table: "SkillSnapshots");

            migrationBuilder.DropIndex(
                name: "IX_SkillSnapshots_AmberSkillsId",
                table: "SkillSnapshots");

            migrationBuilder.DropIndex(
                name: "IX_SkillSnapshots_GreenSkillsId",
                table: "SkillSnapshots");

            migrationBuilder.DropIndex(
                name: "IX_SkillSnapshots_RedSkillsId",
                table: "SkillSnapshots");

            migrationBuilder.DropIndex(
                name: "IX_SkillSetSkillLink_LinkedSkillId",
                table: "SkillSetSkillLink");

            migrationBuilder.DropIndex(
                name: "IX_SkillSetSkillLink_LinkedSkillSetId",
                table: "SkillSetSkillLink");

            migrationBuilder.DropColumn(
                name: "AmberSkillsId",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "GreenSkillsId",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "RedSkillsId",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "LinkedSkillId",
                table: "SkillSetSkillLink");

            migrationBuilder.DropColumn(
                name: "LinkedSkillSetId",
                table: "SkillSetSkillLink");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SkillSnapshots",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmberSkillSetId",
                table: "SkillSnapshots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GreenSkillSetId",
                table: "SkillSnapshots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedSkillSetId",
                table: "SkillSnapshots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "SkillSetSkillLink",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillSetId",
                table: "SkillSetSkillLink",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_SkillSetSkillLink_SkillId",
                table: "SkillSetSkillLink",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSetSkillLink_SkillSetId",
                table: "SkillSetSkillLink",
                column: "SkillSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSetSkillLink_Skills_SkillId",
                table: "SkillSetSkillLink",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSetSkillLink_SkillSets_SkillSetId",
                table: "SkillSetSkillLink",
                column: "SkillSetId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_SkillSets_AmberSkillSetId",
                table: "SkillSnapshots",
                column: "AmberSkillSetId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_SkillSets_GreenSkillSetId",
                table: "SkillSnapshots",
                column: "GreenSkillSetId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_SkillSets_RedSkillSetId",
                table: "SkillSnapshots",
                column: "RedSkillSetId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_Users_UserId",
                table: "SkillSnapshots",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillSetSkillLink_Skills_SkillId",
                table: "SkillSetSkillLink");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSetSkillLink_SkillSets_SkillSetId",
                table: "SkillSetSkillLink");

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
                name: "IX_SkillSetSkillLink_SkillId",
                table: "SkillSetSkillLink");

            migrationBuilder.DropIndex(
                name: "IX_SkillSetSkillLink_SkillSetId",
                table: "SkillSetSkillLink");

            migrationBuilder.DropColumn(
                name: "AmberSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "GreenSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "RedSkillSetId",
                table: "SkillSnapshots");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "SkillSetSkillLink");

            migrationBuilder.DropColumn(
                name: "SkillSetId",
                table: "SkillSetSkillLink");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SkillSnapshots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AmberSkillsId",
                table: "SkillSnapshots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GreenSkillsId",
                table: "SkillSnapshots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RedSkillsId",
                table: "SkillSnapshots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LinkedSkillId",
                table: "SkillSetSkillLink",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LinkedSkillSetId",
                table: "SkillSetSkillLink",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_SkillSetSkillLink_LinkedSkillId",
                table: "SkillSetSkillLink",
                column: "LinkedSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSetSkillLink_LinkedSkillSetId",
                table: "SkillSetSkillLink",
                column: "LinkedSkillSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSetSkillLink_Skills_LinkedSkillId",
                table: "SkillSetSkillLink",
                column: "LinkedSkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSetSkillLink_SkillSets_LinkedSkillSetId",
                table: "SkillSetSkillLink",
                column: "LinkedSkillSetId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_SkillSets_AmberSkillsId",
                table: "SkillSnapshots",
                column: "AmberSkillsId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_SkillSets_GreenSkillsId",
                table: "SkillSnapshots",
                column: "GreenSkillsId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_SkillSets_RedSkillsId",
                table: "SkillSnapshots",
                column: "RedSkillsId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSnapshots_Users_UserId",
                table: "SkillSnapshots",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
