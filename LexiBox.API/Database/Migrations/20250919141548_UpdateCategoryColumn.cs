using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LexiBox.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategoryColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabularies_Category_CategoryId",
                table: "Vocabularies");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Vocabularies_CategoryId",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Vocabularies");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Vocabularies",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_Word",
                table: "Vocabularies",
                column: "Word",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vocabularies_Word",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Vocabularies");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Vocabularies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_CategoryId",
                table: "Vocabularies",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabularies_Category_CategoryId",
                table: "Vocabularies",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
