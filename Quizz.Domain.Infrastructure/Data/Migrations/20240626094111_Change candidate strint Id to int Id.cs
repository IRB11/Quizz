using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizz.Domain.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangecandidatestrintIdtointId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Supprimer les clés étrangères qui dépendent de la colonne à modifier
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Levels_LevelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Levels_EFLevelId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_EFLevelId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "EFLevelId",
                table: "Quizzes");

            // Step 1: Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateResponses",
                table: "CandidateResponses");

            // Step 2: Add a new temporary column with IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "TempId",
                table: "CandidateResponses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");


            // Step 4: Drop the old column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CandidateResponses");

            // Step 5: Rename the new column to the original name
            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "CandidateResponses",
                newName: "Id");

            // Step 6: Add the primary key constraint back
            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateResponses",
                table: "CandidateResponses",
                column: "Id");

            // Recreate foreign key constraints
            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Levels_LevelId",
                table: "Questions",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert foreign key constraints
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Levels_LevelId",
                table: "Questions");

            // Step 1: Add the old column back
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "CandidateResponses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            // Step 2: Copy data from new column to old column
            migrationBuilder.Sql(
                "UPDATE CandidateResponses SET Id = CAST(Id AS nvarchar(450))");

            // Step 3: Drop the new column
            migrationBuilder.DropColumn(
                name: "TempId",
                table: "CandidateResponses");

            // Step 4: Restore foreign key constraints
            migrationBuilder.AddColumn<int>(
                name: "EFLevelId",
                table: "Quizzes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_EFLevelId",
                table: "Quizzes",
                column: "EFLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Levels_LevelId",
                table: "Questions",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Levels_EFLevelId",
                table: "Quizzes",
                column: "EFLevelId",
                principalTable: "Levels",
                principalColumn: "Id");
        }
    }
}

