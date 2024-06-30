#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizz.Domain.Infrastructure.Data.Migrations
{
    public partial class Fixtechno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraints
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Technologies_TechnologyId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Technologies_TechnologyId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Users_Id",
                table: "Technologies");

            // Drop primary key
            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies");

            // Create a new temporary column with identity
            migrationBuilder.AddColumn<int>(
                name: "NewId",
                table: "Technologies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");



            // Drop the old Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Technologies");

            // Rename NewId to Id
            migrationBuilder.RenameColumn(
                name: "NewId",
                table: "Technologies",
                newName: "Id");

            // Add the primary key back
            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies",
                column: "Id");

            // Recreate foreign key constraints without cascade on delete
            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Technologies_TechnologyId",
                table: "Questions",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Technologies_TechnologyId",
                table: "Quizzes",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Users_Id",
                table: "Technologies",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key constraints
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Technologies_TechnologyId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Technologies_TechnologyId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_Users_Id",
                table: "Technologies");

            // Drop primary key
            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies");

            // Add the old Id column back
            migrationBuilder.AddColumn<int>(
                name: "OldId",
                table: "Technologies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Drop the current Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Technologies");

            // Rename OldId back to Id
            migrationBuilder.RenameColumn(
                name: "OldId",
                table: "Technologies",
                newName: "Id");

            // Add the primary key back
            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies",
                column: "Id");

            // Recreate foreign key constraints with cascade on delete
            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Technologies_TechnologyId",
                table: "Questions",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Technologies_TechnologyId",
                table: "Quizzes",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_Users_Id",
                table: "Technologies",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
