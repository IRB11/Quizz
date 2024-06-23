using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quizz.Domain.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Levels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Levels");
        }
    }
}
