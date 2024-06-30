using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizz.Domain.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeresponsestrintIdtointId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            // Step 2: Add a new temporary column with IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "TempId",
                table: "Responses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");


            // Step 4: Drop the old column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Responses");

            // Step 5: Rename the new column to the original name
            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "Responses",
                newName: "Id");

            // Step 6: Add the primary key constraint back
            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop the primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            // Step 2: Add the old column back
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Responses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            // Step 3: Copy data from new column to old column
            migrationBuilder.Sql(
                "UPDATE Responses SET Id = CAST(Id AS nvarchar(450))");

            // Step 4: Drop the new column
            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Responses");

            // Step 5: Add the primary key constraint back
            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "Id");
        }
    }
}
