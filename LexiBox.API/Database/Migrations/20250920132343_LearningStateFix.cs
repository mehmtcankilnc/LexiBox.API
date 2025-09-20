using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiBox.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class LearningStateFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLearned",
                table: "Vocabularies");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Vocabularies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Vocabularies");

            migrationBuilder.AddColumn<bool>(
                name: "IsLearned",
                table: "Vocabularies",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
