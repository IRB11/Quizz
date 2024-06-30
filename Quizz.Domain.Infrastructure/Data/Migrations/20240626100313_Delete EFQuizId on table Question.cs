using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizz.Domain.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteEFQuizIdontableQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_EFQuizId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_EFQuizId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "EFQuizId",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EFQuizId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_EFQuizId",
                table: "Questions",
                column: "EFQuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_EFQuizId",
                table: "Questions",
                column: "EFQuizId",
                principalTable: "Quizzes",
                principalColumn: "Id");
        }
    }
}
