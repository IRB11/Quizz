using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quizz.Domain.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Levels_LevelId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_LevelId",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Agent" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "active" },
                    { 2, "passed" },
                    { 3, "delete" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "EmailAddress", "FirstName", "IsActive", "LastName", "Password", "PhoneNumber", "RoleId", "Salt", "Token" },
                values: new object[,]
                {
                    { 1, "hashedpassword", "john.doe@example.com", "John", true, "Doe", "hashedpassword", "1234567890", 1, null, "tokenvalue" },
                    { 2, "hashedpassword", "jane.smith@example.com", "Jane", true, "Smith", "hashedpassword", "0987654321", 2, null, "tokenvalue" }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "AgentId", "EmailAddress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "john.doe@example.com", "John", "Doe", "1234567890" },
                    { 2, 2, "jane.smith@example.com", "Jane", "Smith", "0987654321" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "AdminId", "Content", "IsActive" },
                values: new object[,]
                {
                    { 1, 1, "Junior", true },
                    { 2, 1, "intermediate", true },
                    { 3, 1, "Senior", true }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "AdminId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Technology1" },
                    { 2, 2, "Technology2" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AdminId", "Content", "IsValid", "LevelId", "TechnologyId", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Sample question content 1", true, 1, 1, "Multiple Choice" },
                    { 2, 1, "Sample question content 2", true, 2, 2, "Short Answer" },
                    { 3, 1, "Sample question content 3", true, 2, 2, "Short Answer" },
                    { 4, 1, "Sample question content 4", true, 2, 2, "Short Answer" }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "AdminId", "AgentId", "CandidateId", "Comment", "Completion", "CompletionTime", "IsValid", "NumberOfQuestion", "QuizzNumber", "Result", "StatusId", "TechnologyId", "URL" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "Sample comment 1", 0.5m, new DateTime(2024, 6, 26, 19, 45, 6, 915, DateTimeKind.Utc).AddTicks(5206), true, 10, "1", 0.5m, 1, 1, "https://example.com/quiz1" },
                    { 2, 1, 2, 2, "Sample comment 2", 0.5m, new DateTime(2024, 6, 26, 19, 45, 6, 915, DateTimeKind.Utc).AddTicks(5211), false, 15, "2", 0.8m, 2, 2, "https://example.com/quiz2" },
                    { 3, 1, 2, 2, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 15, "3", 0m, 1, 2, "https://example.com/quiz2" }
                });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "QuestionId", "QuizId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "Id", "Content", "QuestionId", "isCorrect" },
                values: new object[,]
                {
                    { 1, " Q1 Sample response content 1", 1, true },
                    { 2, " Q1 Sample response content 2", 1, false },
                    { 3, " Q1 Sample response content 3", 1, true },
                    { 4, "Q1 Sample response content 4", 1, false },
                    { 5, " Q2 Sample response content 1", 2, true },
                    { 6, " Q2 Sample response content 2", 2, false },
                    { 7, " Q2 Sample response content 3", 2, true },
                    { 8, "Q2 Sample response content 4", 2, false },
                    { 9, " Q3 Sample response content 1", 3, true },
                    { 10, " Q3 Sample response content 2", 3, false },
                    { 11, " Q3 Sample response content 3", 3, true },
                    { 12, "Q3 Sample response content 4", 3, false },
                    { 13, "Q4 Sample response content 4", 4, false },
                    { 14, " Q4 Sample response content 1", 4, true },
                    { 15, " Q4 Sample response content 2", 4, false },
                    { 16, " Q4 Sample response content 3", 4, true }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Levels_TechnologyId",
                table: "Questions",
                column: "TechnologyId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Levels_TechnologyId",
                table: "Questions");

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionId", "QuizId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionId", "QuizId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionId", "QuizId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionId", "QuizId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionId", "QuizId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionId", "QuizId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionId", "QuizId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumns: new[] { "QuestionId", "QuizId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LevelId",
                table: "Questions",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Levels_LevelId",
                table: "Questions",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
