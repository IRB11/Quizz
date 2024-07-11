using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizz.Domain.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddpropertyResponseIdtoCandidateResponseentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponseId",
                table: "CandidateResponses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompletionTime",
                value: new DateTime(2024, 7, 11, 8, 7, 33, 491, DateTimeKind.Utc).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompletionTime",
                value: new DateTime(2024, 7, 11, 8, 7, 33, 491, DateTimeKind.Utc).AddTicks(7390));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseId",
                table: "CandidateResponses");

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompletionTime",
                value: new DateTime(2024, 7, 10, 7, 12, 58, 148, DateTimeKind.Utc).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompletionTime",
                value: new DateTime(2024, 7, 10, 7, 12, 58, 148, DateTimeKind.Utc).AddTicks(4723));
        }
    }
}
